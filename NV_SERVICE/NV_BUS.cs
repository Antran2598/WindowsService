using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NV_SHARED;

namespace NV_SERVICE
{
    class NV_BUS: MarshalByRefObject, INV_BUS
    {
        public List<ChitietNV> laydanhsach()
        {
            List<ChitietNV> nhanviens = new NV_DAO().laytatca();
            return nhanviens;
        }

        public List<ChitietNV> Search(String keyword)
        {
            List<ChitietNV> nhanviens = new NV_DAO().Selectbyword(keyword);
            return nhanviens;
        }

        public ChitietNV Getdetails(int manv)
        {
            ChitietNV nhanvien = new NV_DAO().Selectbycode(manv);
            return nhanvien;

        }

        public bool Addnew(ChitietNV newnhanvien)
        {
            bool result = new NV_DAO().Insert(newnhanvien);
            return result;
        }


        public bool Delete(int manv)
        {
            bool result = new NV_DAO().Delete(manv);
            return result;
        }


        public bool Update(ChitietNV newnhanvien)
        {
            bool result = new NV_DAO().Update(newnhanvien);
            return result;
        }
    }
}
