using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace MapLayer.Mappers
{
    public class SirketMapper
    {
        public static DTOs.SirketDTO Mapper(Model.Models.Sirket model)
        {
            DTOs.SirketDTO sirketDto = new DTOs.SirketDTO();
            sirketDto.sirketID = model.sirketID;
            sirketDto.sirketAdi = model.sirketAdi;
            sirketDto.Sehir = model.İl.ilAdi;
            sirketDto.sirketPuani = model.sirketPuani;
            sirketDto.Kullanicilar = model.Kullanici.ToList();
            sirketDto.Araclar = model.Arac.ToList();
            sirketDto.aracSayisi = model.aracSayisi;
            sirketDto.acikAdres = model.acikAdres;
            return sirketDto;
        }
    }
}
