namespace VideoIntelligence.WebApp.Enums
{

    /// <summary>
    /// Defines the types of audio effects that can be detected.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=AudioEffectType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum AudioEffectType
    {
        /// <summary>
        /// Represents a baseline audio effect
        /// </summary>
        Baseline,

        /// <summary>
        /// Represents a clapping audio effect
        /// </summary>
        Clapping,

        /// <summary>
        /// Represents speech as an audio effect
        /// </summary>
        Speech,

        /// <summary>
        /// Represents silence as an audio effect
        /// </summary>
        Silence,

        /// <summary>
        /// Represents a gunshot audio effect
        /// </summary>
        Gunshot,

        /// <summary>
        /// Represents an alarm ringing audio effect
        /// </summary>
        AlarmRinging,

        /// <summary>
        /// Represents a dog barking audio effect
        /// </summary>
        DogBarking,

        /// <summary>
        /// Represents crying as an audio effect
        /// </summary>
        Crying,

        /// <summary>
        /// Represents crowd reactions as an audio effect
        /// </summary>
        CrowdReactions,

        /// <summary>
        /// Represents an explosion audio effect
        /// </summary>
        Explosion,

        /// <summary>
        /// Represents laughter as an audio effect
        /// </summary>
        Laughter,

        /// <summary>
        /// Represents screaming as an audio effect
        /// </summary>
        Screaming,

        /// <summary>
        /// Represents the sound of breaking glass
        /// </summary>
        BreakingGlass,

        /// <summary>
        /// Represents a siren wailing audio effect
        /// </summary>
        SirenWailing,

        /// <summary>
        /// Represents a siren or alarm audio effect
        /// </summary>
        SirenOrAlarm,

        /// <summary>
        /// Represents a gunshot or explosion audio effect
        /// </summary>
        GunshotOrExplosion,

        /// <summary>Represents a dog audio effect.</summary>
        Dog,

        /// <summary>
        /// Represents a bell ringing audio effect
        /// </summary>
        BellRinging,

        /// <summary>
        /// Represents a bird audio effect
        /// </summary>
        Bird,

        /// <summary>
        /// Represents a cat audio effect
        /// </summary>
        Cat,

        /// <summary>
        /// Represents an engine audio effect
        /// </summary>
        Engine,

        /// <summary>
        /// Represents music playing as an audio effect
        /// </summary>
        MusicPlaying,

        /// <summary>
        /// Represents a thunderstorm audio effect
        /// </summary>
        Thunderstorm,

        /// <summary>
        /// Represents an unlabeled audio effect
        /// </summary>
        Unlabeled
    }
}
