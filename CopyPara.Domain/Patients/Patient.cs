using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Domain.Patients;

public class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public float Wheight { get; set; }
}
