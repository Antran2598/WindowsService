using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV_SHARED
{
    public interface INV_BUS
    {
        List<ChitietNV> laydanhsach();
        List<ChitietNV> Search(String keyword);
        ChitietNV Getdetails(int manv);
        bool Addnew(ChitietNV newnhanvien);
        bool Delete(int manv);
        bool Update(ChitietNV newnhanvien);
    }
}
