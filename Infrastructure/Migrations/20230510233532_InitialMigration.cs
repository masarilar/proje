using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AracBeklemeDurumlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeklemeDurum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracBeklemeDurumlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UstBirimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Birimler_Birimler_UstBirimId",
                        column: x => x.UstBirimId,
                        principalTable: "Birimler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalismaTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Yol = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Uzanti = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RefTip = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategoriTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategoriTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AracTipiId = table.Column<int>(type: "int", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ModelYili = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rengi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DemirbasDurumu = table.Column<short>(type: "smallint", nullable: false),
                    BaslangicKilometresi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    KilometredeBakimaGider = table.Column<short>(type: "smallint", nullable: false),
                    Plakasi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RuhsatNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Resimleri = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Araclar_AracTipleri_AracTipiId",
                        column: x => x.AracTipiId,
                        principalTable: "AracTipleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    GorevId = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    CepTelefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EvTelefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DahiliNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    YakiniAdSoyad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YakiniTelefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    KanGrubu = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Cinsiyet = table.Column<short>(type: "smallint", nullable: false),
                    MedeniDurum = table.Column<short>(type: "smallint", nullable: false),
                    AskerlikDurum = table.Column<short>(type: "smallint", nullable: false),
                    FirmaSicilNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CalismaTurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Birimler_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birimler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_CalismaTurleri_CalismaTurId",
                        column: x => x.CalismaTurId,
                        principalTable: "CalismaTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    KategoriTipId = table.Column<int>(type: "int", nullable: false),
                    Yetkileri = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategoriler_KategoriTipleri_KategoriTipId",
                        column: x => x.KategoriTipId,
                        principalTable: "KategoriTipleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soforler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    EhliyetYetkinlikleri = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soforler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soforler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duyurular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Basligi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AnaResim = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Metin = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    YayinTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YayinBitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KeywordAlani = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    SliderGoster = table.Column<short>(type: "smallint", nullable: false),
                    SliderSirasi = table.Column<int>(type: "int", nullable: false),
                    YorumEkle = table.Column<short>(type: "smallint", nullable: false),
                    Begenme = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duyurular_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AracTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    KaydedenId = table.Column<int>(type: "int", nullable: false),
                    DegistirenId = table.Column<int>(type: "int", nullable: false),
                    KayitTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegisiklikTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslangicNoktasi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BitisNoktasi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ToplamKilometre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    GidisTarihSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AracBeklemeDurumId = table.Column<int>(type: "int", nullable: false),
                    AracTalepDurum = table.Column<short>(type: "smallint", nullable: false),
                    AracId = table.Column<int>(type: "int", nullable: true),
                    SoforId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AracTalepleri_AracBeklemeDurumlari_AracBeklemeDurumId",
                        column: x => x.AracBeklemeDurumId,
                        principalTable: "AracBeklemeDurumlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AracTalepleri_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AracTalepleri_Soforler_SoforId",
                        column: x => x.SoforId,
                        principalTable: "Soforler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_AracTipiId",
                table: "Araclar",
                column: "AracTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_AracTalepleri_AracBeklemeDurumId",
                table: "AracTalepleri",
                column: "AracBeklemeDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_AracTalepleri_AracId",
                table: "AracTalepleri",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_AracTalepleri_SoforId",
                table: "AracTalepleri",
                column: "SoforId");

            migrationBuilder.CreateIndex(
                name: "IX_Birimler_UstBirimId",
                table: "Birimler",
                column: "UstBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Duyurular_KategoriId",
                table: "Duyurular",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_KategoriTipId",
                table: "Kategoriler",
                column: "KategoriTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_BirimId",
                table: "Kullanicilar",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_CalismaTurId",
                table: "Kullanicilar",
                column: "CalismaTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_GorevId",
                table: "Kullanicilar",
                column: "GorevId");

            migrationBuilder.CreateIndex(
                name: "IX_Soforler_KullaniciId",
                table: "Soforler",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracTalepleri");

            migrationBuilder.DropTable(
                name: "Dosyalar");

            migrationBuilder.DropTable(
                name: "Duyurular");

            migrationBuilder.DropTable(
                name: "AracBeklemeDurumlari");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Soforler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "AracTipleri");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "KategoriTipleri");

            migrationBuilder.DropTable(
                name: "Birimler");

            migrationBuilder.DropTable(
                name: "CalismaTurleri");

            migrationBuilder.DropTable(
                name: "Gorevler");
        }
    }
}
