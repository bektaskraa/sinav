using System;
using System.Collections.Generic;

namespace Sinav.Models;

public partial class Boyut
{
    public int Id { get; set; }

    public string? Adi { get; set; }

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
