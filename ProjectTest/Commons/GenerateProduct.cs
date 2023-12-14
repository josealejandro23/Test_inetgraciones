using Test_jvarg361.Entitys;

namespace Test_jvarg361.Commons
{
    public class GenerateProduct
    {
        public static Product GenerateRandomProduct(IEnumerable<int> categoriesIds, IEnumerable<int> suppliersIds)
        {
            //se crean valores al azar y se sobrecarga un objeto product
            int categoriId = ObtenerValorAlAzar(categoriesIds);
            int supplierId = ObtenerValorAlAzar(suppliersIds);
            int UnitsInStock = new Random().Next(1,50);
            int QuantityPerUnit = new Random().Next(1,5);
            int UnitPrice = new Random().Next(1,1000);
            string name = obtenerNombre(RandomNames);

            Product p = new Product
            {
                Name = name,
                SupplierId = supplierId,
                CategoryId = categoriId,
                UnitsInStock = UnitsInStock,
                QuantityPerUnit = QuantityPerUnit,
                UnitPrice = UnitPrice
            };
            return p;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //funcion para retornar una posición aleatorio de una lista
        static int ObtenerValorAlAzar(IEnumerable<int> coleccion)
        {
            Random random = new Random();
            int ran = random.Next(coleccion.Count());

            return coleccion.ElementAt(ran);
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //funcion para retornar una posición aleatorio de una lista de nombres
        static string obtenerNombre(string[] coleccion)
        {
            Random random = new Random();
            int ran = random.Next(coleccion.Count());

            return coleccion[ran];
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        private static string[] RandomNames =
        {
            "Hyundai HN5848F Digital .28dp NI  15 in",
            "Hyundai HN5864F Dig .28dp NI 1280 15 in  1280x102",
            "Hyundai HN7448M M/M .42dp NI      17 in",
            "Hyundai HN7870A Dig .28dp NI 1280 17 in  1280x102",
            "Sony CDU76E CdRom             IDE 4X",
            "Fujitsu   1.44Mb Floppy Drive     3.5 in",
            "Sony      1.44MB Floppy Drive     3.5 in",
            "CONNER CFA270A              270MB IDE",
            "SEAGATE                      270MB IDE",
            "Maxtor 7540AV                540MB IDE",
            "Quantum LPS540AT            540MB IDE",
            "Seagate ST3660A             540MB IDE",
            "Maxtor 7850AV                850MB IDE",
            "Quantum 850TBAT              850MB IDE",
            "Seagate.ST51080A           1.08gb IDE",
            "Logitech Dexxa mouse  2 button",
            "Hyundai HL7948M M/M .39dp NI      17 in",
            "Creative Value 32 M/M Kit          12x",
            "Addtron   8 PT Hub 100BaseTX",
            "Canon BJ10sx Portable BJ Ptr Whte 10 in",
            "Wisecom   14.4 Fx/Md/Vc           Int",
            "HP    51633A Black Ink Cart",
            "Creative Value CD                   4x",
            "Creative Discovery 16 PNP           4x",
            "Hurr PC Blst 5PV100 MT    AMD K5  1.2gb",
            "Hurricane MT14SV39  SVGA bond   14 in",
            "Hurr PC Blst 5PV100 DT    AMD K5  1.2gb",
            "Hurr PCB LX  5PX133 MT    Intel  1.6gb",
            "Hurr PCB LX  5PX166 MT    Intel  2.1gb",
            "CHEER VC14 NI *I/B .28 SVGA       14 in",
            "CITIZEN GSX190S PRINTER",
            "Tripp Lite UPS 1050VA 705W Battery Back Up Tower ",
            "APC Back-UPS Pro 420 - UPS - CA 230 V - 420 VA - ",
            "Tripplite Omnipro 1050            110V",
            "Tripp Lite UPS Smart 2200VA 1700W Tower AVR 120V ",
            "APC Smart-UPS 3000VA - UPS - CA 230 V - 3000 VA -",
            "APC SmartUps v/s 1400 Intl      220v",
            "MB 486DX4           W/B k     35v VLB",
            "APC Smart-UPS 2200VA - UPS - CA 230 V - 2200 VA -",
            "APC Smart-UPS 1000INET - UPS - CA 230 V - 1000 VA",
            "APC Smart-UPS 1400INET - UPS - CA 230 V - 1400 VA",
            "APC SmartUps 450 Net Intl       220v",
            "Intel CPU 486D2/66                  5v",
            "Hurricane MT14VM Mono VGA bond  14 in",
            "Epson Stylus 400 Color Printer    110V",
            "Toshiba 5302B CdRom            IDE 4X",
            "Epson Stylus 600 Color Printer    110V",
            "Estabilizador Tripplite LS500       110v",
            "Tripp Lite 600W Line Conditioner w/ AVR / Surge P",
            "Tripp Lite 1000W Line Conditioner w/ AVR / Surge ",
            "Tripp Lite 2000W Line Conditioner w/ AVR / Surge ",
            "Tripplite BC280 Intl 50Hz       220v",
            "Tripplite BC450 Intl 50Hz       220v",
            "Tripplite XBC450 Pro Intl 60Hz  220v",
            "Maxtor 7425AV               427MB IDE",
            "Tripplite BC675 Intl 50Hz       220v",
            "Tripplite XBC675 Pro Intl 60Hz  220v",
            "Tripplite Omnipro 280 Intl 50Hz  220v",
            "FUJITSU M2682T R           350MB IDE",
            "Tripp Lite OmniPro 450 - UPS - AC 220 V - 450 VA ",
            "Hurr Blister Pack Mouse 3B DB9",
            "ADAPTEC AHA2940 KT BUS MSTR  PCI SCSI",
            "AOC  .39 color SVGA bond         14 in",
            "Conner CFS850A              850MB IDE",
            "Tripplite Omnipro 675 Intl 50Hz  220v",
            "MB 486DX4          w/000k     35v VLB",
            "Canon BJC4100 720X360 CLR         10 in",
            "Tripplite XOmnipro1050 Intl 60Hz 220v",
            "WISECOM   NE2000 16 BIT 2N1 ISA",
            "Okidata ML320 10 in           220V EpsonIBM emula",
            "Okidata ML321 15 in           220V Epson/IBM emul",
            "Tripplite XOmnipro1400 Intl 60Hz 220v",
            "Seagate.ST5850A             850mb IDE",
            "CPU COOLING FAN  486",
            "Tripplite XSmartNet 2200 Int 60Hz 220v",
            "Epson LQ1170 24 PIN               15 in",
            "Creative Grph Blstr 3D Rambus 4mb PCI",
            "Aztech Explorer SP Ext M/M          2x",
            "Fujitsu M1606TAU            1.09gb IDE",
            "Creative Video Blaster Kit      30 FPS",
            "USRob Big Picture Kit w/Modem  1622 w/ software",
            "Vivitar Digital Camera 2000    320x240 24 bits co",
            "Vivitar Digital Camera 3000    500x800 24 bits co",
            "Creative Home Office                4x",
            "Hurricane 5P  B/B - Tower Case",
            "Epson LX 300 - Printer - B/W - dot-matrix - A4, R",
            "Hurricane MT14SV28  .28 bond    14 in",
            "Canon BJ200EX  300x300 R       10 in",
            "APC BackUps 400                  110v",
            "Newcom    33.6 Fax/Mdm            Int",
            "Aims Video Highway TVTuner PALM",
            "MSWindows 3.11         DSP SOEM 3.5 in",
            "MS Windows 95 & Plus   DSP SOEM 3.5 in",
            "MS Windows 95 & Plus   DSP EOEM 3.5 in",
            "Conner CFS425A              426MB IDE",
            "MS Windows 95 & Plus   DSP SOEM  CDR",
            "MS Windows 95 & Plus   DSP EOEM  CDR",
            "Canon BJC600 720x360 CLR R      10 in",
            "MS Windows 95 DSP SR2     EOEM  CDR",
            "WESTERN DIGITAL AC1270       270MB IDE",
            "MS Windows 95 DSP SR2     SOEM  CDR",
            "Microsoft Windows 95 OSR2 - Complete package - 1 ",
            "APC BackUps 280                  110v",
            "MS Windows 95 DSP SR2     SOEM 3.5 in",
            "Hurr  Microsoft Win 95 Man Kit  SPN",
            "Boca      14.4 Fx/Md         220v Ext",
            "Longshine NE2000 16 BIT 2N1 ISA",
            "Hurr  Microsoft Fun Pack Vol 1  SPN",
            "MS Consumer Value Pack      SOEM  CDR",
            "Novell Intranetware 4.11  10 Usr   CD",
            "APC BackUps 450                  110v",
            "Sharp JX96DR Drum Unit",
            "Canon BJ200E            R       10 in",
            "Canon BJC4000 730x360 C R       10 in",
            "Boca      14.4 Fx/Md/Sft MNP      Int",
            "Canon BJC210  360x360 CLR        10 in",
            "Epson serial interface       LQ1170",
            "MB P5 200 Apollo PA2000 000k    PCI",
            "Hurr Budget Mouse       3B DB9",
            "Samsung Syncmaster 3NE SVGA .28dp  14 in",
            "Seagate.ST31720A            1.7gb IDE",
            "ADAPTEC AVA1515 KT     ISA SCSI  HD/CD ONLY+SOFTW",
            "Epson LQ 570+ - Impresora - B/N - matriz de punto",
            "Generic   28.8 v34 Fx/Mdm         Int",
            "Aspen     28.8 v34 Fx/Md     220v Ext",
            "Generic   14.4 Fx/Md              Ext",
            "Creative Labs CdRom            IDE 6X",
            "MB 386SX/33 or Lower               ISA",
            "Boca      14.4 Fx/Md/Vc MNP       Int",
            "Western Digital              635MB IDE",
            "Epson FX1170 9PIN                 15 in",
            "Chinon    1.2MB  Floppy Drive    5.25 in",
            "MB 386DX/33 or Lower w/CPU         ISA",
            "MB 486 SX/40 or Lower w/CPU        VLB",
            "Powernet  8 PT hub 10BaseT",
            "MB 486DX2          C/256K     35V VLB",
            "Canon BJC610  720x720 CLR         10 in",
            "MB P5 60/66 Misc Boards    256k    PCI",
            "Generic   2400 Modem              Int",
            "Epson DFX8000 9PIN WIDE 1066CPS",
            "Generic   2400 Modem              Ext",
            "Diamond Stealth 64 2MB VLB DRAM",
            "Gen VGA 16b 512k  **Misc Prods**  ISA",
            "Boca      14.4 Fx/Md/Hd MNP       Int",
            "JVC Archiver  CDR Drv  2x4 INT SCSI w/Software",
            "Wisecom   28.8 v34 Fx/Md          Ext",
            "Citizen GSX190 9PIN Printer",
            "Diamond Steal 24              1MB VLB",
            "Okidata ML591 15 in           220v Epson/IBM emul",
            "Quantum LPS540S             540MB SCS",
            "Fujitsu M2654SA              2.0gb SCS",
            "EPSON LQ1070 24 PIN 269 CPS 10 in",
            "Fujitsu    Win95 Keybd       English",
            "Sharp JX330 Flatbed Color SCSI 600DPI",
            "Adaptec AHA1510 8 bt         ISA SCS  HD/CD ONLY+",
            "Tripplite Omnipro 675             110v",
            "MB 386DX/40  w/64k w/128k w/256k   ISA",
            "Nec       1.2MB  Floppy Drive    5.25 in",
            "APC SmartUps 2000                110v",
            "MB 486SLC2/50 or 66                ISA",
            "APC SmartUps 700                 110v",
            "MB 486SLC2/50 or 66 or BL3/75      VLB",
            "MB Alaris NXP80/90/100 w/CPU      VLB",
            "Mitsumi FX001D  CDRom         IDE 2X",
            "Intel CPU 486DX4/100                3v",
            "APC BackUps 1200                 110v",
            "Aspen     28.8 v34 Fx/Md          Ext",
            "ADAPTEC AHA2742AT KT  EISA SCSI  BUS MASTERING+SO",
            "MB 486 w/486DX2/50                 VLB",
            "Televideo Telemedia Spn           4x",
            "Generic   NE2000 8 bit **Misc**  ISA",
            "Canon BJC600E 720x360 CLR         10 in",
            "Canon BJC4000 730x360 CLR         10 in",
            "Aztech Voyager M/M Kit              6x",
            "APC SmartUps 1000 110v",
            "Diamond 4000E SpCD M/M Kit        4x",
            "Creative Performance                6x",
            "Aztech Explorer  M/M Kit Ext        2x",
            "Gen VGA 32b 512k>1mb             VLB",
            "PRIMEDIA HS28 M/M SPEAKERS",
            "DataRace  Fax/Mdm/Ether 14.4   PCMCIA",
            "Tripplite Omnipro 450             110v",
            "IOMEGA DITTO 420 TBU 110V PARALLEL EXT",
            "KDS 1710            .42 SVGA       17 in",
            "Boca      14.4 Fx/Md SF MNP       Ext",
            "Fujitsu M2684SAU             540MB SCS",
            "ULSI 387DX Math CoProcessor",
            "Epson FX 880 - Printer - B/W - dot-matrix - Legal",
            "GoldStar CdRom                 IDE 4X",
            "ADAPTEC AVA1505 KT     ISA SCSI  CD ONLY+SOFTWARE",
            "DTC Vl Bus IDE I/O 2278         VLB",
            "Gen Vl Bus IDE I/O    Non S/N   VLB",
            "Diamond Stealth 64 1MB VLB DRAM",
            "APC SmartUps 400                 110v",
            "MB 486DX  64k/128k/256k  No S/N  ISA",
            "Mitsumi   1.2MB  Floppy Drive    5.25 in",
            "Tripplite BC PERS 280             110v",
            "Best Data 2496 Fx/Md              Int",
            "Actiontec  14.4 Fax Modem      PCMCIA",
            "ADAPTEC AVA2842VL KT   VLB SCSI  BUS MASTERING+SO"
        };
    }
}
