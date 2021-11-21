using System.IO;

namespace TrProtocol.Models
{
    [Serializer(typeof(TrackedProjectileReferenceSerializer))]
    public partial class TrackedProjectileReference
    {
        private class TrackedProjectileReferenceSerializer : FieldSerializer<TrackedProjectileReference>
        {
            protected override TrackedProjectileReference _Read(BinaryReader br)
            {
                var proj = new TrackedProjectileReference
                {
                    ExpectedOwner = br.ReadInt16()
                };
                if (proj.ExpectedOwner == -1)
                    return proj;
                proj.ExpectedIdentity = br.ReadInt16();
                proj.ExpectedType = br.ReadInt16();
                return proj;
            }

            protected override void _Write(BinaryWriter bw, TrackedProjectileReference t)
            {
                bw.Write(t.ExpectedOwner);
                if (t.ExpectedOwner == -1)
                    return;
                bw.Write(t.ExpectedIdentity);
                bw.Write(t.ExpectedType);
            }
        }
    }
}
