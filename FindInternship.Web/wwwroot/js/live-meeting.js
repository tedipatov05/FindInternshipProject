
const switchMode = document.querySelector('button.mode-switch'),
    body = document.querySelector('body');


switchMode.addEventListener('click', () => {
    body.classList.toggle('dark');
});



class DailyCallManager {
    constructor() {
        this.call = Daily.createCallObject();
        this.currentRoomUrl = null;
        this.initialize();
    }


    async initialize() {
        this.setupEventListeners();
        document
            .getElementById('toggle-camera')
            .addEventListener('click', () => this.toggleCamera());
        document
            .getElementById('toggle-mic')
            .addEventListener('click', () => this.toggleMicrophone());
    }

    setupEventListeners() {

        const events = {
            'active-speaker-change': this.handleActiveSpeakerChange.bind(this),
            error: this.handleError.bind(this),
            'joined-meeting': this.handleJoin.bind(this),
            'left-meeting': this.handleLeave.bind(this),
            'participant-joined': this.handleParticipantJoinedOrUpdated.bind(this),
            'participant-left': this.handleParticipantLeft.bind(this),
            'participant-updated': this.handleParticipantJoinedOrUpdated.bind(this),
        };

        Object.entries(events).forEach(([event, handler]) => {

            this.call.on(event, handler);
        });
    }

    handleJoin(event) {
        const tracks = event.participants.local.tracks;

        console.log(`Successfully joined: ${this.currentRoomUrl}`);


        this.updateAndDisplayParticipantCount();


        document.getElementById('leave-btn').disabled = false;

        document.getElementById('toggle-camera').disabled = false;
        document.getElementById('toggle-mic').disabled = false;
        document.getElementById('camera-selector').disabled = false;
        document.getElementById('mic-selector').disabled = false;

        this.setupDeviceSelectors();


        Object.entries(tracks).forEach(([trackType, trackInfo]) => {
            this.updateUiForDevicesState(trackType, trackInfo);
        });
    }

    // const joinCall = async () => {
    //     if (!callObject) return;
    //     // Set the local participants name
    //     await callObject.setUserName(userName);
    //     // ... rest of your code
    //   };


    handleLeave() {
        console.log('Successfully left the call');

        document.getElementById('leave-btn').disabled = true;
        document.getElementById('join-btn').disabled = false;

        document.getElementById('toggle-camera').disabled = true;
        document.getElementById('toggle-mic').disabled = true;

        const cameraSelector = document.getElementById('camera-selector');
        const micSelector = document.getElementById('mic-selector');
        cameraSelector.selectedIndex = 0;
        micSelector.selectedIndex = 0;
        cameraSelector.disabled = true;
        micSelector.disabled = true;


        const videosDiv = document.getElementById('videos');
        while (videosDiv.firstChild) {
            videosDiv.removeChild(videosDiv.firstChild);
        }
    }


    handleError(e) {
        console.error('DAILY SENT AN ERROR!', e.error ? e.error : e.errorMsg);
    }


    handleParticipantLeft(event) {
        const participantId = event.participant.session_id;

        this.destroyTracks(['video', 'audio'], participantId);

        document.getElementById(`video-container-${participantId}`)?.remove();

        this.updateAndDisplayParticipantCount();
    }

    handleParticipantJoinedOrUpdated(event) {
        const { participant } = event;
        const participantId = participant.session_id;
        const isLocal = participant.local;
        const tracks = participant.tracks;

        this.updateAndDisplayParticipantCount();

        if (!document.getElementById(`video-container-${participantId}`)) {


            this.createVideoContainer(participantId, participant.user_name);
        }

        if (!document.getElementById(`audio-${participantId}`) && !isLocal) {
            this.createAudioElement(participantId);
        }

        Object.entries(tracks).forEach(([trackType, trackInfo]) => {
            if (trackInfo.persistentTrack) {

                if (!(isLocal && trackType === 'audio')) {
                    this.startOrUpdateTrack(trackType, trackInfo, participantId);
                }
            } else {
                this.destroyTracks([trackType], participantId);
            }

            if (trackType === 'video') {
                this.updateVideoUi(trackInfo, participantId);
            }


            if (isLocal) {
                this.updateUiForDevicesState(trackType, trackInfo);
            }
        });
    }

    handleActiveSpeakerChange(event) {
        document.getElementById(
            'active-speaker'
        ).textContent = `Active Speaker: ${event.activeSpeaker.peerId}`;
    }


    async joinRoom(roomUrl, joinToken = null) {
        if (!roomUrl) {
            console.error('Room URL is required to join a room.');
            return;
        }

        this.currentRoomUrl = `https://findinternship.daily.co/${roomUrl}`

        const joinOptions = { url: this.currentRoomUrl };
        if (joinToken) {
            joinOptions.token = joinToken;
            console.log('Joining with a token.');
        } else {
            console.log('Joining without a token.');
        }

        try {

            document.getElementById('join-btn').disabled = true;
            document.getElementById('actions').style.display = 'flex';
           

            await this.call.join(joinOptions);
            let name = document.getElementById('participant-name').value;

            await this.call.setUserName(name);
           
        } catch (e) {
            console.error('Join failed:', e);
        }
    }


    createVideoContainer(participantId, name) {

        const videoContainer = document.createElement('div');
        videoContainer.id = `video-container-${participantId}`;
        videoContainer.className = 'video-participant';
        if (document.getElementById('videos').children.length == 1) {
            videoContainer.style = 'background-image: url(/img/no-camera.jpg); background-repeat: no-repeat;background-size: cover;width:100%;height:100%;background-position: center;border-radius: 16px;';
            document.getElementById('videos').insertBefore(videoContainer, document.getElementById('side-videos'));
            const sessionIdOverlay = document.createElement('div');
            sessionIdOverlay.className = 'name-tag';
            sessionIdOverlay.textContent = name;
            videoContainer.appendChild(sessionIdOverlay);

            const videoEl = document.createElement('video');
            videoEl.className = 'video-element';
            videoEl.style = ""
            videoContainer.appendChild(videoEl);

        } else {
            document.getElementById('videos').style.width = '100%'
            let top = document.getElementById('side-videos').children.length == 0 ? 0 : 0.5
            document.getElementById('side-videos').style.width = '30%';
            document.getElementById('videos').firstElementChild.style.width = "60%";

            videoContainer.style = `background-image: url(/img/no-camera.jpg); background-repeat: no-repeat;background-size: cover;width:100%;margin-top: ${top}rem;background-position: center;border-radius: 12px;`;
            document.getElementById('side-videos').appendChild(videoContainer);
            const sessionIdOverlay = document.createElement('div');
            sessionIdOverlay.className = 'name-tag';
            sessionIdOverlay.textContent = name;
            videoContainer.appendChild(sessionIdOverlay);

            const videoEl = document.createElement('video');
            videoEl.className = 'video-element';
            videoEl.style = ""
            videoContainer.appendChild(videoEl);
        }

    }


    createAudioElement(participantId) {
        const audioEl = document.createElement('audio');
        audioEl.id = `audio-${participantId}`;
        document.body.appendChild(audioEl);
    }


    startOrUpdateTrack(trackType, track, participantId) {
        const selector =
            trackType === 'video'
                ? `#video-container-${participantId} video.video-element`
                : `audio-${participantId}`;

        const trackEl =
            trackType === 'video'
                ? document.querySelector(selector)
                : document.getElementById(selector);

        if (!trackEl) {
            console.error(
                `${trackType} element does not exist for participant: ${participantId}`
            );
            return;
        }


        const existingTracks = trackEl.srcObject?.getTracks();
        const needsUpdate = !existingTracks?.includes(track.persistentTrack);


        if (needsUpdate) {
            trackEl.srcObject = new MediaStream([track.persistentTrack]);


            trackEl.onloadedmetadata = () => {
                trackEl
                    .play()
                    .catch((e) =>
                        console.error(
                            `Error playing ${trackType} for participant ${participantId}:`,
                            e
                        )
                    );
            };
        }
    }


    updateVideoUi(track, participantId) {
        let videoEl = document
            .getElementById(`video-container-${participantId}`)
            .querySelector('video.video-element');

        switch (track.state) {
            case 'off':
            case 'interrupted':
            case 'blocked':
                videoEl.style.display = 'none'; // Hide video but keep container
                break;
            case 'playable':
            default:

                videoEl.style.display = '';
                break;
        }
    }


    destroyTracks(trackTypes, participantId) {
        trackTypes.forEach((trackType) => {
            const elementId = `${trackType}-${participantId}`;
            const element = document.getElementById(elementId);
            if (element) {
                element.srcObject = null;
                element.parentNode.removeChild(element);
            }
        });
    }


    toggleCamera() {
        this.call.setLocalVideo(!this.call.localVideo());

    }


    toggleMicrophone() {
        this.call.setLocalAudio(!this.call.localAudio());
    }


    updateUiForDevicesState(trackType, trackInfo) {

        if (trackType === 'video') {
            let videoStatus = this.call.localVideo() ? 'On' : 'Off';

            if (videoStatus == 'On') {
                document.getElementById('toggle-camera').style.backgroundImage = 'url(../img/camera-enabled.jpg)';

            }
            else {
                document.getElementById('toggle-camera').style.backgroundImage = 'url(../img/camera-disabled.jpg)';
            }


        } else if (trackType === 'audio') {
            let audioStatus = this.call.localAudio() ? 'On' : 'Off';

            if (audioStatus == 'On') {
                document.getElementById('toggle-mic').style.backgroundImage = 'url(../img/mic-icon.png)'

            } else {
                document.getElementById('toggle-mic').style.backgroundImage = 'url(../img/mic-icon-disabled.png)'

            }

        }
    }


    async setupDeviceSelectors() {
        const selectedDevices = await this.call.getInputDevices();
        const { devices: allDevices } = await this.call.enumerateDevices();

        const selectors = {
            videoinput: document.getElementById('camera-selector'),
            audioinput: document.getElementById('mic-selector'),
        };


        Object.values(selectors).forEach((selector) => {
            selector.innerHTML = '';
            const promptOption = new Option(
                `Select a ${selector.id.includes('camera') ? 'camera' : 'microphone'}`,
                '',
                true,
                true
            );
            promptOption.disabled = true;
            selector.appendChild(promptOption);
        });

        allDevices.forEach((device) => {
            if (device.label && selectors[device.kind]) {
                const isSelected =
                    selectedDevices[device.kind === 'videoinput' ? 'camera' : 'mic']
                        .deviceId === device.deviceId;
                const option = new Option(
                    device.label,
                    device.deviceId,
                    isSelected,
                    isSelected
                );
                selectors[device.kind].appendChild(option);
            }
        });

        document.getElementById('video-controls').style.display = 'flex';

        Object.entries(selectors).forEach(([deviceKind, selector]) => {
            selector.addEventListener('change', async (e) => {
                const deviceId = e.target.value;
                const deviceOptions = {
                    [deviceKind === 'videoinput' ? 'videoDeviceId' : 'audioDeviceId']:
                        deviceId,
                };
                await this.call.setInputDevicesAsync(deviceOptions);
            });
        });

    }


    updateAndDisplayParticipantCount() {
        const participantCount =
            this.call.participantCounts().present +
            this.call.participantCounts().hidden;
        document.getElementById(
            'participant-count'
        ).textContent = `Participants: ${participantCount}`;
    }


    async leave() {
        try {
            await this.call.leave();
            document.querySelectorAll('#videos video, audio').forEach((el) => {
                el.srcObject = null;
                el.remove();
            });
        } catch (e) {
            console.error('Leaving failed', e);
        }
    }
}


document.addEventListener('DOMContentLoaded', async () => {
    const dailyCallManager = new DailyCallManager();

    document
        .getElementById('join-btn')
        .addEventListener('click', async function () {

            document.getElementById('meeting-form').style.display = 'none';
            document.getElementById('actions').style.display = 'none';

            const roomName = document.getElementById('room-name').value.trim();
            // const joinToken =
            //     document.getElementById('join-token').value.trim() || null;
            await dailyCallManager.joinRoom(roomName, null);
        });

    document.getElementById('leave-btn').addEventListener('click', function () {
        document.getElementById('meeting-form').style.display = 'block';
        document.getElementById('video-controls').style.display = 'none';
        document.getElementById('actions').style.display = 'none';
        dailyCallManager.leave();
        let url = new URL(window.location);
        window.location = url.origin + '/Meeting/All'


    });
});
