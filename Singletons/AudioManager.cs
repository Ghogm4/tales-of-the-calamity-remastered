using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

public partial class AudioManager : Node
{
    private List<AudioStreamPlayer> _playerPool = new();
    private AudioStreamPlayer _bgmPlayer = new();
    private int _initialCount = 40;
    // Populate the pool with initial number of players at the beginning.
    public override void _Ready()
    {
        for (int i = 0; i < _initialCount; ++i)
        {
            AddToPool();
        }
    }
    // Get an available AudioStreamPlayer from pool. If there is no, create a new one.
    private AudioStreamPlayer GetFromPool()
    {
        foreach (AudioStreamPlayer player in _playerPool)
        {
            if (player.Playing) continue;
            return player;
        }
        return AddToPool();
    }
    // Add a new AudioStreamPlayer to the pool and return it.
    private AudioStreamPlayer AddToPool()
    {
        AudioStreamPlayer player = new();
        AddChild(player);
        _playerPool.Add(player);
        return player;
    }
    // Retrieve an available player from pool and use it to play SFX.
    public void PlaySFX(string sfxName)
    {
        AudioStream stream = ResourceLoader.Load<AudioStream>($"res://Assets/Sound/{sfxName}.wav");
        GetFromPool().Stream = stream;
        GetFromPool().Play();
    }
    // Use the _bgmPlayer to play BGM.
    public void PlayBGM(string bgmName)
    {
        AudioStream stream = ResourceLoader.Load<AudioStream>($"res://Assets/Sound/{bgmName}.mp3");
        _bgmPlayer.Stream = stream;
        _bgmPlayer.Play();
    }
}
