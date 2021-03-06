﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public abstract class AbstractState {

    protected int _stateID;
    protected bool _stateFinished = false;
    protected VideoPlayer _videoPlayer;
    protected string _nameOfVideo;

    //In this method you will start playing the video (base) with the possibility to override so that you can start certain variables (timers, counters, etc.)
    public virtual void StartState()
    {
        PlayVideoByName(_videoPlayer, _nameOfVideo);
    }

    //In this method you will have to set the bool variable 'stateFinished' when the state is finished, 
    //so that you can switch to the next state.
    public abstract void RunState();

    //With this method we can call up if states it finished to switch to next state, 
    //or if it still running.
    public bool IsFinished()
    {
        return _stateFinished;
    }

    //With this method we will redefine all necessary variable to stop and reset the state to be able to switch to the next state and reuse this state.
    public virtual void StopState()
    {
        _stateFinished = false;
    }

    //This method will be used to check if all parameters exist or if they are set properly. 
    //This can be used to override and check for each state separate, which then can be run by the manager script to run over all methods.
    public virtual bool CheckParameters()
    {
        if (!_stateFinished)
            return true;
        else
        {
            UnityEngine.Debug.LogWarning("Parameter 'stateFinished' is set on 'true' before entering stage.");
            return false;
        }
    }

    //This method will be used to play any video by name for all the states, so it does has to be written again for every new state.
    protected void PlayVideoByName(VideoPlayer videoPlayer, string nameOfVideo)
    {
        videoPlayer.url = "Assets/Footage/" + nameOfVideo + ".MP4";
        videoPlayer.Play();
    }
}
