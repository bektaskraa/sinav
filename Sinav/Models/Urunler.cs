using System;
using System.Collections.Generic;

namespace Sinav.Models;

public partial class Urunler
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Aciklama { get; set; }

    public double? Fiyat { get; set; }

    public int? SizeId { get; set; }

    public int? ColorId { get; set; }

    public virtual Renk? Color { get; set; }

    public virtual Boyut? Size { get; set; }
}
