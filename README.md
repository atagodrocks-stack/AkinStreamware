# AkinStreamware
AKIN is an all-in-one Windows live production platform combining professional audio mixing, video switching, multitrack recording, real-time latency compensation, streaming, replay, projection, and remote device control in a unified application.
# AKIN — All-in-One Live Production Studio

**Professional audio. Video production. Recording. Streaming. Synchronization. One platform.**

AKIN is a Windows desktop application designed to bring the capabilities of a professional digital audio mixer, live video switcher, digital audio workstation (DAW), broadcast production system, multitrack recorder, and streaming platform into one integrated environment.

Designed for churches, recording studios, live events, broadcasters, and independent creators, AKIN aims to simplify complex production workflows while providing the control, flexibility, and precision expected from professional production software.

Rather than relying on multiple disconnected applications, AKIN is being designed as a unified production environment where audio, video, recording, synchronization, streaming, replay, and external outputs work together.

> **Project status:** Under development. Features described in this README represent the project's intended capabilities and roadmap; availability depends on implementation and testing.

## Core Vision

Most live production workflows require multiple tools for audio mixing, video switching, recording, streaming, projection, and post-production. Managing these tools independently can introduce unnecessary complexity, routing problems, synchronization errors, and workflow limitations.

AKIN aims to address these challenges through a modular, hardware-aware production engine with centralized processing and an integrated interface.

The primary goals are:

- Professional audio mixing with independent control of every source.
- Flexible video capture, composition, and live switching.
- Accurate source synchronization and latency compensation.
- Real-time latency-compensated multitrack recording.
- Built-in recording, streaming, replay, and projection.
- Remote control and network-connected production devices.
- Efficient operation across a range of Windows hardware.

## Key Features

### 1. Professional Digital Audio Mixer

AKIN is designed around a professional digital mixer rather than a collection of basic volume controls.

Each audio source will have an independent channel with controls such as:

- Gain, fader, mute, solo, and pan.
- Input and output metering.
- Signal routing and bus assignment.
- Input monitoring and output selection.
- Equalization and dynamics processing.
- Effects and individual channel settings.

The intended interface combines the accessibility of a live-streaming mixer with the flexibility of a professional digital mixing console.

### 2. Independent Audio Device Selection

AKIN aims to provide granular control over physical and virtual audio devices.

For example, a user should be able to select:

- A webcam for video.
- A headset microphone for audio input.
- Headphones connected to that headset for monitoring.
- A separate audio interface for recording or output.

These selections should remain independent instead of automatically binding the webcam's microphone to its video source or relying exclusively on Windows' default audio device.

Planned device support includes compatible USB microphones, headsets, audio interfaces, built-in audio devices, application audio, virtual devices, and network-connected sources, subject to operating-system and driver capabilities.

### 3. Professional Audio Processing

AKIN is intended to include built-in digital signal processing without requiring external plugins for core functionality.

Planned processing tools include:

- **Graphic EQ:** frequency-band control.
- **Parametric EQ:** adjustable frequency, gain, and Q.
- **Compressor:** threshold, ratio, attack, release, and makeup gain.
- **Gate and expander:** control of unwanted low-level signals.
- **Limiter:** peak control.
- **Reverb and delay:** spatial and time-based effects.
- **Additional effects:** other useful processing tools as the engine develops.

Sidechain processing and advanced routing will be configurable rather than unexpectedly enabled.

### 4. Flexible Audio Routing and Multiple Mixes

AKIN aims to support independent mixes for different destinations.

Examples include:

- Main or front-of-house mix.
- Streaming mix.
- Recording mix.
- Monitor mixes.
- Subgroups and buses.
- Independent output feeds.

A source should be routable to appropriate destinations without forcing every destination to use the same final mix.

A configurable routing matrix will provide visibility into the signal path and make complex production setups easier to manage.

### 5. Real-Time Per-Source Latency Compensation

One of AKIN's central planned capabilities is per-source latency compensation.

Different microphones, USB interfaces, software inputs, cameras, and network devices can introduce different amounts of delay. If their signals are combined without appropriate synchronization, related events may not line up correctly.

AKIN is designed to provide individual timing adjustments for each appropriate source.

Planned capabilities include:

- Per-source delay settings.
- Fine adjustments in milliseconds and, where practical, audio samples.
- Reference-source selection.
- Automatic alignment where technically reliable.
- Manual calibration.
- Saved calibration settings.
- Audio-to-audio, video-to-video, and audio-to-video synchronization.

The engine must distinguish actual device and processing latency from the intentional delay applied to align sources.

### 6. Waveform-Based Manual Calibration

AKIN's planned manual synchronization interface will allow users to inspect prerecorded calibration samples visually.

The user will be able to:

- Record or load short samples from multiple sources.
- Display waveforms on a common timeline.
- Overlay waveforms for direct comparison.
- Zoom in to inspect transients and individual samples.
- Drag waveforms to identify the required timing offset.
- View offsets in milliseconds and, where appropriate, samples.
- Preview compensated timing.
- Lock or reset the selected calibration.

The measured offset must configure the actual source-compensation engine. This is intended to be a calibration tool, not merely a waveform editor.

### 7. Real-Time Latency-Compensated Multitrack Recording

AKIN is designed to record individual sources independently while maintaining a common recording timeline.

For example, a session could contain separate tracks for:

- Vocals.
- Keyboard.
- Bass.
- Guitar.
- Drums.
- Playback.
- Host microphone.
- Network-connected phone audio.
- Selected buses.
- Final program mix.

**The defining requirement is that latency compensation must be integrated into the recording and production architecture.**

AKIN must not rely solely on recording unsynchronized tracks and moving finished stems afterward.

Where technically possible, earlier-arriving sources should be buffered so their signals align with the selected synchronization reference before being committed to the synchronized recording timeline.

The system should account for capture timestamps, device-reported latency, buffer sizes, processing delay, and clock differences where measurable.

Planned recording options include:

- Latency-compensated multitrack recording.
- Raw multitrack recording that preserves original timing.
- Individual track and stem exports.
- Synchronized multitrack exports.
- Final program recordings.
- Audio-only and audio/video recordings.

Raw timing information should be preserved where appropriate, allowing users to revisit synchronization decisions without unnecessarily losing the original capture information.

The exact degree of synchronization accuracy will depend on hardware, drivers, timestamps, clocking, and the recording format. The implementation must report these limitations honestly.

### 8. Video Capture, Scenes, and Live Switching

AKIN aims to support compatible video sources such as:

- USB and built-in webcams.
- Capture cards.
- Screen and window capture.
- Video files and images.
- Network cameras.
- Phone cameras.
- Other supported capture devices.

A scene-composition system will allow users to combine sources, graphics, text, overlays, backgrounds, and effects.

Planned controls include:

- Position, scale, crop, and rotation.
- Layer ordering and visibility.
- Color adjustments.
- Source-specific filters.
- Scene transitions.
- Independent audio and video switching behavior.

### 9. Preview, Program, and Multiview

A professional preview/program workflow will allow users to prepare a scene before taking it live.

Planned functionality includes:

- Separate preview and program displays.
- Direct cuts and configurable transitions.
- Multiview layouts.
- Source labels and status indicators.
- Audio meters.
- Output monitoring.

The interface is intended to support both straightforward productions and more complex live workflows.

### 10. Rolling Buffer and Instant Replay

AKIN aims to maintain a configurable rolling buffer of recent production content.

Users should be able to preserve and replay recent moments without unnecessarily interrupting the live production.

Planned options include configurable buffer duration, replay controls, and saving selected sections.

The implementation will need to balance replay duration, video quality, audio synchronization, memory use, and storage requirements.

### 11. Streaming and Recording

AKIN is intended to provide integrated recording and streaming controls.

Planned streaming destinations and protocols include YouTube, Facebook, Twitch, custom RTMP destinations, SRT, and other supported output methods.

Configuration options may include:

- Resolution and frame rate.
- Video and audio bitrate.
- Encoder selection.
- Network settings.
- Recording format.
- Recording destination.
- Audio output selection.

Actual availability will depend on the selected encoder, protocol implementation, platform requirements, and testing.

### 12. Projection and Multiple Outputs

AKIN aims to support external displays and production outputs, including:

- Projectors.
- Secondary monitors.
- LED-wall feeds.
- Clean program feeds.
- Preview and multiview displays.
- Recording and streaming outputs.
- Compatible network outputs.

The goal is to make projection and external output part of the same production workflow rather than requiring a separate application for basic operation.

### 13. Remote Control and Distributed Production

AKIN is planned around **centralized production processing with distributed control**.

The host computer performs the main audio and video processing, recording, encoding, streaming, and synchronization.

Other computers, tablets, and phones may eventually connect as:

- Remote control surfaces.
- Audio or video operator stations.
- Monitoring displays.
- Network audio/video sources.
- Network output destinations.

Subject to permissions, remote operators could control mixer levels, EQ, effects, routing, scenes, transitions, recording, streaming, and replay.

The architecture should separate control traffic from monitoring media so that video previews do not unnecessarily delay control commands.

A future companion phone application could turn a phone into a camera and microphone source without making AKIN dependent on any single third-party camera application.

### 14. Hardware-Aware Performance

AKIN is intended to scale according to the computer's capabilities.

The default video configuration is planned to be 720p at 30 FPS, with configurable resolution, frame rate, encoding, and quality settings.

The application should monitor relevant system resources, including:

- CPU and GPU usage.
- Memory consumption.
- Frame rate and dropped frames.
- Audio buffering and synchronization.
- Device availability.
- Recording and streaming status.
- Network performance.

Low-resource configurations and more powerful production systems should be supported through appropriate performance profiles.

### 15. Reliability and Project Management

Planned reliability features include:

- Local project and settings storage.
- Saved scenes and device assignments.
- Persistent mixer and synchronization settings.
- Automatic saving and project recovery.
- Device-disconnection alerts.
- Automatic reconnection attempts.
- Recording recovery where technically possible.
- Diagnostics and error reporting.

Core production functionality should work offline. Internet access should be reserved for features that actually require it, such as streaming, online authentication, and updates.

## Intended Technology Direction

The final technology stack will be selected according to performance, reliability, licensing, and integration requirements.

Technologies under consideration include:

- C++ and suitable Windows desktop frameworks.
- Windows audio APIs such as WASAPI and compatible ASIO integrations.
- Windows Media Foundation and appropriate video-capture APIs.
- FFmpeg for suitable media-processing and encoding tasks.
- A dedicated DSP engine for audio processing.
- Timestamp-aware recording and synchronization architecture.
- Network protocols for remote control and audio/video transport.

These are candidate technologies, not a claim that every component has already been implemented or selected.

## Development Principles

AKIN is intended to follow several engineering principles:

1. **Real functionality over mockups:** controls must perform their advertised actions.
2. **Synchronization by design:** latency compensation must be considered throughout capture, processing, monitoring, recording, and export.
3. **Modular architecture:** audio, video, recording, networking, and user-interface systems should be independently maintainable.
4. **Hardware awareness:** performance should adapt to available resources.
5. **Honest capability reporting:** unsupported or untested features must be identified clearly.
6. **Offline-first core:** basic production should not depend on an internet connection.
7. **Professional workflows:** the interface should accommodate both simple setups and complex productions.
8. **Testable implementation:** important signal-processing and synchronization behavior should be validated with repeatable tests.

## Development Roadmap

The intended development sequence includes:

1. Core desktop application and project structure.
2. Audio and video device management.
3. Audio engine and professional mixer.
4. Scene composition and live switching.
5. Recording and program outputs.
6. Multitrack recording.
7. Per-source latency compensation.
8. Waveform-based manual calibration.
9. Real-time synchronized multitrack recording.
10. Rolling buffer and replay.
11. Streaming and projection.
12. Remote control and network sources.
13. Performance optimization and recovery.
14. Testing, packaging, and Windows installer.

The order may change as architectural dependencies become clearer.

## Target Platforms

- Windows 10
- Windows 11

The initial focus is a standalone Windows desktop application, with remote-device support planned as part of the broader architecture.

## Project Status

AKIN is under development. The feature descriptions above communicate the intended direction and design requirements; they should not be interpreted as confirmation that every feature is currently available.

The project aims to grow into a unified platform for professional live production, recording, synchronization, and streaming.

## Long-Term Vision

AKIN aims to make complex audio/video production more coherent by bringing mixing, switching, recording, synchronization, replay, projection, and remote operation into one integrated environment.

The ambition is not simply to combine existing tools, but to build a production engine in which these systems work together from the ground up.

**AKIN — One production environment. Complete creative control.**
