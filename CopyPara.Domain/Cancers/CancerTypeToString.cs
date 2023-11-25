using System.Security.Cryptography;

namespace CopyPara.Domain.Cancers;

public static class CancerTypeToString
{
    public static string ToFastString(this CancerType type) => type switch
    {
        CancerType.CRANIOSPINAL => "CRANIOSPINAL",
        CancerType.BREAST => "BREAST",
        CancerType.BREAST_SPECIAL => "BREAST SPECIAL",
        CancerType.HEAD_AND_NECK => "HEAD AND NECK",
        CancerType.ABDOMEN => "ABDOMEN",
        CancerType.PELVIS => "PELVIS",
        CancerType.CRANE => "CRANE",
        CancerType.LUNG => "LUNG",
        CancerType.LUNG_SPECIAL => "LUNG SPECIAL",
        CancerType.WHOLE_BRAIN => "WHOLE BRAIN",
        _ => "Not applicable"
    };
}
