using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetParticlesModule : IPacket
    {
        public ParticleOrchestraType Type { get; set; }
        public ParticleOrchestraSettings Settings { get; set; }
    }
}