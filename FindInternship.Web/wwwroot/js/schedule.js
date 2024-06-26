jQuery(document).ready(function ($) {
    var transitionEnd = 'webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend';
    var transitionsSupported = ($('.csstransitions').length > 0);

    if (!transitionsSupported) transitionEnd = 'noTransition';



    function schedule(element) {
        this.element = element;
        this.timeline = this.element.find('.timeline');
        this.timelineItems = this.timeline.find('li');
        this.timelineItemsNumber = this.timelineItems.length;
        this.timelineStart = getScheduleTimestamp(this.timelineItems.eq(0).text());

        this.timelineUnitDuration = getScheduleTimestamp(this.timelineItems.eq(1).text()) - getScheduleTimestamp(this.timelineItems.eq(0).text());

        this.eventsWrapper = this.element.find('.events');
        this.eventsGroup = this.eventsWrapper.find('.events-group');
        this.singleEvents = this.eventsGroup.find('.single-event');
        this.eventSlotHeight = this.eventsGroup.eq(0).children('.top-info').outerHeight();

        this.modal = this.element.find('.event-modal');
        this.modalHeader = this.modal.find('.header');
        this.modalHeaderBg = this.modal.find('.header-bg');
        this.modalBody = this.modal.find('.body');
        this.modalBodyBg = this.modal.find('.body-bg');
        this.modalMaxWidth = 800;
        this.modalMaxHeight = 480;

        this.animating = false;

        this.initSchedule();
    }

    schedule.prototype.initSchedule = function () {
        this.scheduleReset();
        this.initEvents();
    };

    schedule.prototype.scheduleReset = function () {
        if (!this.element.hasClass('js-full')) {
            this.eventSlotHeight = this.eventsGroup.eq(0).children('.top-info').outerHeight();
            this.element.addClass('js-full');
            this.placeEvents();
            this.element.hasClass('modal-is-open') && this.checkEventModal();
        } else if (this.element.hasClass('modal-is-open')) {
            this.checkEventModal('desktop');
            this.element.removeClass('loading');
        } else {
            this.element.removeClass('loading');
        }
    };

    schedule.prototype.initEvents = function () {
        var self = this;

        this.singleEvents.each(function () {

            var durationLabel = '<span class="event-date">' + $(this).data('start') + ' - ' + $(this).data('end') + '</span>';
            $(this).children('a').prepend($(durationLabel));


            $(this).on('click', 'a', function (event) {
                event.preventDefault();
                if (!self.animating) self.openModal($(this));
            });
        });


        this.modal.on('click', '.close', function (event) {
            event.preventDefault();
            if (!self.animating) self.closeModal(self.eventsGroup.find('.selected-event'));
        });
        this.element.on('click', '.cover-layer', function (event) {
            if (!self.animating && self.element.hasClass('modal-is-open')) self.closeModal(self.eventsGroup.find('.selected-event'));
        });
    };

    schedule.prototype.placeEvents = function () {
        var self = this;
        this.singleEvents.each(function () {

            var start = getScheduleTimestamp($(this).attr('data-start')),
                duration = getScheduleTimestamp($(this).attr('data-end')) - start;

            var eventTop = self.eventSlotHeight * (start - self.timelineStart) / self.timelineUnitDuration,
                eventHeight = self.eventSlotHeight * duration / self.timelineUnitDuration;

            $(this).css({
                top: (eventTop - 1) + 'px',
                height: (eventHeight + 1) + 'px'
            });
        });

        this.element.removeClass('loading');
    };

    schedule.prototype.openModal = function (event) {
        var self = this;
        this.animating = true;

        let meetingId = event.attr('id');
        
        let display = meetingId == '' ? 'none' : 'flex';

        let t = $("input[name='__RequestVerificationToken']").val();

        $.ajax({
            type: 'GET',
            url: `/Meeting/Details/${meetingId}`, 
            dataType: 'json',
            headers: {
                "RequestVerificationToken": t
            },
            success: function (data) {
                if (data.isExists) {
                    //update event name and time
                    let eventName = '';
                    event.find('.event-name').each(function () {
                        eventName += $(this).text() + ' ';
                    });


                    self.modalHeader.find('.event-name').text(eventName);
                    self.modalHeader.find('.event-date').text(event.find('.event-date').text());
                    if (data.isCompany) {

                        self.modalHeader.find('.d-flex').html(`<div class="mt-4" style="display: flex; z-index:3; "><a href="/Meeting/Delete/${meetingId}" class="btn btn-danger" style="font-size: large;margin-right: 1rem;">Delete</a><a href="/Meeting/Edit/${meetingId}" class="btn btn-warning" style="font-size: large">Edit</a></div>`)
                    }
                    self.modal.attr('data-event', event.parent().attr('data-event'));

                    //update event content
                    let value = event.parent().attr('data-content');

                    let displayAddress = data.meeting.isOnline == true ? 'none' : 'block';
                    let displayJoin = data.isHaveRoom == true && data.isTeacher == false ? 'block' : 'none';
                    let displayRoom = data.meeting.isOnline == true && data.isHaveRoom==false && data.isCompany ? 'block' : 'none';


                    self.modalBody.find('.event-info').html(`<div class="mt-4">
                                                    <h4>Материали</h4>
                                                    <div style="margin-top: 1rem;" id="materials">
                                                    </div> 
                                                    <h4 style="margin-top: 1.4rem;">Описание</h4>
                                                    <div style="margin-top: 0.5rem; margin-left: 1rem;font-weight: 400;">
                                                        ${data.meeting.description}
                                                    </div>
                                                    <h4 style="margin-top: 2rem; display: ${displayAddress}">Адрес</h4>
                                                    <div style="margin-top: 0.5rem; margin-left: 1rem;font-weight: 400;display:${displayAddress}">
                                                        ${data.meeting.address}
                                                    </div>
                                                    <h4 style="margin-top: 10px">Лектор</h4>
                                                    <div class="img-div">
                                                        <img class="image--cover" src="${data.meeting.lector.profilePictureUrl}"></img>
                                                        <div style="margin-left: 1rem;font-weight: 400;">${data.meeting.lector.name}</div>
                                                    </div>
                                                    <div id="createRoom-div" style="display: ${displayRoom}">
                                                        <a onclick="createDailyRoom('${eventName.split(' - ')[0].trim()}', '${meetingId}')"><button class="bn632-hover bn26">Създай стая</button></a>
                                                    </div>
                                                    <div id="join-div" style="display: ${displayJoin}">
                                                        <a href="/Room/JoinRoom?meetingId=${meetingId}"><button class="bn632-hover bn26">Присъедини се</button></a>
                                                    </div>
                                                   
                                                 </div>`);


                    for (let material of data.meeting.materials) {
                        let a = document.createElement('a');
                        a.setAttribute('target', '_blank');
                        a.setAttribute('href', material.url);
                        a.style = 'margin-top:0.5 rem';
                        a.innerHTML = ` <div class="input-group-text pl-2 pr-2" style="margin-left: 10px; margin-top: 0.5rem;">
                                            <div style="display: flex; flex-direction: row;"><img src="/img/google-docs.png" style="height: 26px; width: 26px"></img>
                                                <div class="pl-1 pt-1 text-dark" style="font-size: medium; padding-top:2px; margin-left: 0.5rem">${material.name}</div>
                                            </div>
                                       </div>`;


                        document.getElementById('materials').appendChild(a);

                    }




                    self.element.addClass('content-loaded');

                    self.element.addClass('modal-is-open');

                    setTimeout(function () {
                        event.parent('li').addClass('selected-event');
                    }, 10);


                    var eventTop = event.offset().top - $(window).scrollTop(),
                        eventLeft = event.offset().left,
                        eventHeight = event.innerHeight(),
                        eventWidth = event.innerWidth();

                    var windowWidth = $(window).width(),
                        windowHeight = $(window).height();

                    var modalWidth = (windowWidth * .8 > self.modalMaxWidth) ? self.modalMaxWidth : windowWidth * .8,
                        modalHeight = (windowHeight * .8 > self.modalMaxHeight) ? self.modalMaxHeight : windowHeight * .8;

                    var modalTranslateX = parseInt((windowWidth - modalWidth) / 2 - eventLeft),
                        modalTranslateY = parseInt((windowHeight - modalHeight) / 2 - eventTop);

                    var HeaderBgScaleY = modalHeight / eventHeight,
                        BodyBgScaleX = (modalWidth - eventWidth);

                    //change modal height/width and translate it
                    self.modal.css({
                        top: eventTop + 'px',
                        left: eventLeft + 'px',
                        height: modalHeight + 'px',
                        width: modalWidth + 'px',
                    });
                    transformElement(self.modal, 'translateY(' + modalTranslateY + 'px) translateX(' + modalTranslateX + 'px)');

                    //set modalHeader width
                    self.modalHeader.css({
                        width: eventWidth + 'px',
                    });
                    //set modalBody left margin
                    self.modalBody.css({
                        marginLeft: eventWidth + 'px',
                    });

                    //change modal modalHeaderBg height/width and scale it
                    self.modalHeaderBg.css({
                        height: eventHeight + 'px',
                        width: eventWidth + 'px',
                    });
                    transformElement(self.modalHeaderBg, 'scaleY(' + HeaderBgScaleY + ')');

                    self.modalHeaderBg.one(transitionEnd, function () {
                        //wait for the  end of the modalHeaderBg transformation and show the modal content
                        self.modalHeaderBg.off(transitionEnd);
                        self.animating = false;
                        self.element.addClass('animation-completed');
                    });


                    //if browser do not support transitions -> no need to wait for the end of it
                    if (!transitionsSupported) self.modal.add(self.modalHeaderBg).trigger(transitionEnd);



                }
                else {
                    toastr.error('\u0422\u0430\u0437\u0438\u0020\u0441\u0440\u0435\u0449\u0430\u0020\u043d\u0435\u0020\u0441\u044a\u0449\u0435\u0441\u0442\u0432\u0443\u0432\u0430'.normalize());
                }

            }

            
        })


        
    };

    schedule.prototype.closeModal = function (event) {
        var self = this;


        this.animating = true;

        var eventTop = event.offset().top - $(window).scrollTop(),
            eventLeft = event.offset().left,
            eventHeight = event.innerHeight(),
            eventWidth = event.innerWidth();

        var modalTop = Number(self.modal.css('top').replace('px', '')),
            modalLeft = Number(self.modal.css('left').replace('px', ''));

        var modalTranslateX = eventLeft - modalLeft,
            modalTranslateY = eventTop - modalTop;

        self.element.removeClass('animation-completed modal-is-open');

        //change modal width/height and translate it
        this.modal.css({
            width: eventWidth + 'px',
            height: eventHeight + 'px'
        });
        transformElement(self.modal, 'translateX(' + modalTranslateX + 'px) translateY(' + modalTranslateY + 'px)');

        //scale down modalBodyBg element
        transformElement(self.modalBodyBg, 'scaleX(0) scaleY(1)');
        //scale down modalHeaderBg element
        transformElement(self.modalHeaderBg, 'scaleY(1)');

        this.modalHeaderBg.one(transitionEnd, function () {
            //wait for the  end of the modalHeaderBg transformation and reset modal style
            self.modalHeaderBg.off(transitionEnd);
            self.modal.addClass('no-transition');
            setTimeout(function () {
                self.modal.add(self.modalHeader).add(self.modalBody).add(self.modalHeaderBg).add(self.modalBodyBg).attr('style', '');
            }, 10);
            setTimeout(function () {
                self.modal.removeClass('no-transition');
            }, 20);

            self.animating = false;
            self.element.removeClass('content-loaded');
            event.removeClass('selected-event');
        });


        if (!transitionsSupported) self.modal.add(self.modalHeaderBg).trigger(transitionEnd);
    }

    schedule.prototype.checkEventModal = function (device) {
        this.animating = true;
        var self = this;

        if (self.element.hasClass('modal-is-open')) {
            self.modal.addClass('no-transition');
            self.element.addClass('animation-completed');
            var event = self.eventsGroup.find('.selected-event');

            var eventTop = event.offset().top - $(window).scrollTop(),
                eventLeft = event.offset().left,
                eventHeight = event.innerHeight(),
                eventWidth = event.innerWidth();

            var windowWidth = $(window).width(),
                windowHeight = $(window).height();

            var modalWidth = (windowWidth * .8 > self.modalMaxWidth) ? self.modalMaxWidth : windowWidth * .8,
                modalHeight = (windowHeight * .8 > self.modalMaxHeight) ? self.modalMaxHeight : windowHeight * .8;

            var HeaderBgScaleY = modalHeight / eventHeight,
                BodyBgScaleX = (modalWidth - eventWidth);

            setTimeout(function () {
                self.modal.css({
                    width: modalWidth + 'px',
                    height: modalHeight + 'px',
                    top: (windowHeight / 2 - modalHeight / 2) + 'px',
                    left: (windowWidth / 2 - modalWidth / 2) + 'px',
                });
                transformElement(self.modal, 'translateY(0) translateX(0)');

                self.modalHeader.css({
                    width: eventWidth + 'px',
                });

                self.modalBody.css({
                    marginLeft: eventWidth + 'px',
                });

                self.modalHeaderBg.css({
                    height: eventHeight + 'px',
                    width: eventWidth + 'px',
                });

                transformElement(self.modalHeaderBg, 'scaleY(' + HeaderBgScaleY + ')');
            }, 10);

            setTimeout(function () {
                self.modal.removeClass('no-transition');
                self.animating = false;
            }, 20);
        }
    };

    var schedules = $('.cd-schedule');
    var objSchedulesPlan = [];

    if (schedules.length > 0) {
        schedules.each(function () {

            objSchedulesPlan.push(new schedule($(this)));
        });
    }

    function getScheduleTimestamp(time) {

        time = time.replace(/ /g, '');
        var timeArray = time.split(':');
        var timeStamp = parseInt(timeArray[0]) * 60 + parseInt(timeArray[1]);
        return timeStamp;
    }

    function transformElement(element, value) {
        element.css({
            '-moz-transform': value,
            '-webkit-transform': value,
            '-ms-transform': value,
            '-o-transform': value,
            'transform': value
        });
    }
});