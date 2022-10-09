namespace Reversivecell.Laser.Logic.Avatar.Change
{
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Debug;

    public class LogicAvatarChange
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicAvatarChange"/> class.
        /// </summary>
        public LogicAvatarChange()
        {
            // LogicAvatarChange.
        }

        /// <summary>
        ///     Destructs this instance.
        /// </summary>
        public virtual void Destruct()
        {
            // Destruct.
        }

        /// <summary>
        ///     Gets the <see cref="LogicAvatarChange"/> type.
        /// </summary>
        public virtual int GetAvatarChangeType()
        {
            Debugger.Error("LogicAvatarChange::getAvatarChangeType() must be overridden");
            return 0;
        }

        /// <summary>
        ///     Decodes this instance.
        /// </summary>
        public virtual void Decode(ByteStream stream)
        {
            // Decode.
        }

        /// <summary>
        ///     Encodes this instance.
        /// </summary>
        public virtual void Encode(ChecksumEncoder encoder)
        {
            // Encode.
        }

        /// <summary>
        ///     Applies the avatar change to the specified <see cref="LogicClientAvatar"/> instance.
        /// </summary>
        public virtual void ApplyAvatarChange(LogicClientAvatar avatar)
        {
            // ApplyAvatarChange.
        }
    }
}
