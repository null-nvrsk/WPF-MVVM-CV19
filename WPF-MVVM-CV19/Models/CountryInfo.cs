using System.Collections.Generic;

namespace WPF_MVVM_CV19.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}