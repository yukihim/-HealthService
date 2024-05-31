﻿using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.MyDocument;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialVanBanPhapLyCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialVanBanPhapLyCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var test1 = _context.Documents.FirstOrDefault(p => p.code == "abc");
            if (test1 == null)
            {
                _context.Documents.Add(
                    new MyDocument.Document
                    {
                        DVKCBId = 1,
                        title = "Douglas",
                        code = "abc",
                        description = "douglas.adams@fortytwo.com",
                        fullText = "asdasfjnkdfa",
                        medical_product = "thuoc",
                        province = "Ho Chi Minh",
                        validation = new System.DateTime(2023, 10, 3),
                        expiration = new System.DateTime(2024, 5, 6),
                        published = true,
                        approved = true,
                        showed = true
                    });
            }
            var test2 = _context.Documents.FirstOrDefault(p => p.code == "abc");
            if (test2 == null)
            {
                _context.Documents.Add(
                    new MyDocument.Document
                    {
                        DVKCBId = 1,
                        title = "CC21KTM1",
                        code = "abc",
                        description = "douglas.adams@fortytwo.com",
                        fullText = "bsfd bdnaksf",
                        medical_product = "thuoc test",
                        province = "Ho Chi Minh",
                        validation = new System.DateTime(2023, 1, 31),
                        expiration = new System.DateTime(2024, 2, 28),
                        published = true,
                        approved = true,
                        showed = true
                    });
            }
            var test3 = _context.Documents.FirstOrDefault(p => p.code == "abc");
            if (test3 == null)
            {
                _context.Documents.Add(
                    new MyDocument.Document
                    {
                        DVKCBId = 1,
                        title = "CC21KTM1",
                        code = "abc",
                        description = "khung.khung@forty.com",
                        fullText = "asdasdas asdasd",
                        medical_product = "giay",
                        province = "Ha Noi",
                        validation = new System.DateTime(2023, 2, 31),
                        expiration = new System.DateTime(2024, 2, 27),
                        published = true,
                        approved = true,
                        showed = true
                    });
            }
            var test4 = _context.Documents.FirstOrDefault(p => p.code == "abc");
            if (test4 == null)
            {
                _context.Documents.Add(
                    new MyDocument.Document
                    {
                        DVKCBId = 1,
                        title = "CC21KTM1",
                        code = "abc",
                        description = "dien.dien@forty.com",
                        fullText = "asdasda asfasd",
                        medical_product = "giay test",
                        province = "Ho Chi Minh",
                        validation = new System.DateTime(2023, 1, 30),
                        expiration = new System.DateTime(2024, 2, 25),
                        published = true,
                        approved = true,
                        showed = true
                    });
            }
            var test5 = _context.Documents.FirstOrDefault(p => p.code == "abc");
            if (test5 == null)
            {
                _context.Documents.Add(
                    new MyDocument.Document
                    {
                        DVKCBId = 1,
                        title = "CC21KTM1",
                        code = "abc",
                        description = "haha.haha@fortyone.com",
                        fullText = "adsfsdf adfasdfa",
                        medical_product = "khan",
                        province = "Ho Chi Minh",
                        validation = new System.DateTime(2023, 1, 29),
                        expiration = new System.DateTime(2024, 2, 8),
                        published = true,
                        approved = true,
                        showed = true
                    });
            }
        }
    }
}
