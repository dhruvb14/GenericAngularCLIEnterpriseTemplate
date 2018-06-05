using System;

namespace Brownbag.Data.Interfaces {
  public interface IAuditable {
    Guid CreatedBy { get; set; }

    DateTime CreatedDate { get; set; }

    Guid? UpdatedBy { get; set; }

    DateTime? UpdatedDate { get; set; }
  }
}