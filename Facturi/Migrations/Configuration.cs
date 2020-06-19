namespace Facturi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Facturi.FacturiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Facturi.FacturiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. 

            List<Banca> banci = new List<Banca> {
                new Banca{ Id=1, Nume="BCR" },
                new Banca{ Id=2, Nume="BRD" },
                new Banca{ Id=3, Nume="BT" } 
            };
            
            List<Cont> conturi = new List<Cont> {
                new Cont{ Id=1, IBAN="RO81269758364573", BancaId=1, Moneda="RON", SoldInitial=5000, DataDeschideriiContului = new DateTime(2020,5,1), ListaOperatiuni=new List<Operatiune>{
                    new Operatiune{ Id=1, Denumire="Plata Factura",
                        isFix=true, CostFix=5,
                        isPercentage=true, PercentageValue=0.02
                    } }
                },
                new Cont{ Id=2, IBAN="RO91273123652362", BancaId=1, Moneda="RON", SoldInitial=6000, DataDeschideriiContului = new DateTime(2020,5,5), ListaOperatiuni=new List<Operatiune>{
                    new Operatiune{ Id=1, Denumire="Plata Factura",
                        isFix=true, CostFix=10,
                        isPercentage=true, PercentageValue=0.09
                    } }
                },
                new Cont{ Id=3, IBAN="RO11129093024230", BancaId=2, Moneda="RON", SoldInitial=1000, DataDeschideriiContului = new DateTime(2020,4,4), ListaOperatiuni=new List<Operatiune>{
                    new Operatiune{ Id=1, Denumire="Plata Factura",
                        isFix=true, CostFix=2,
                        isPercentage=true, PercentageValue=0.01
                    } }
                },
                new Cont{ Id=4, IBAN="RO54879879238982", BancaId=3, Moneda="RON", SoldInitial=300, DataDeschideriiContului = new DateTime(2020,3,1), ListaOperatiuni=new List<Operatiune>{
                    new Operatiune{ Id=1, Denumire="Plata Factura",
                        isFix=true, CostFix=8,
                        isPercentage=false
                    } }
                },
                new Cont{ Id=4, IBAN="RO2343242348982", BancaId=3, Moneda="EUR", SoldInitial=200, DataDeschideriiContului = new DateTime(2020,3,1), ListaOperatiuni=new List<Operatiune>{
                    new Operatiune{ Id=1, Denumire="Plata Factura",
                        isFix=true, CostFix=8,
                        isPercentage=false
                    } }
                }
            };
            foreach(var cont in conturi) {
                if (cont.Sold != null) continue;

                cont.Sold = cont.SoldInitial;
                cont.DataSold = cont.DataDeschideriiContului;
            }
              
            List<Companie> comapnii = new List<Companie> {
                new Companie { Id = 1, Nume = "Practica 2020 S.R.L.", Email = "practica2020@gmail.com", ListaConturi = conturi },
                new Companie { Id = 2, Nume = "Oracle", Prioritate=1, Email = "info@oracle.com", ListaConturi = new List<Cont>{
                    new Cont{ Id=100, IBAN="RO3338126234346573", Moneda = "RON", BancaId=1}
                } },
                new Companie { Id = 3, Nume = "Google", Prioritate=2, Email = "info@google.com", ListaConturi = new List<Cont>{
                    new Cont{ Id=101, IBAN="RO3333333333333333", Moneda = "RON", BancaId=2}
                } },
                new Companie { Id = 4, Nume = "Apple", Prioritate=6, Email = "info@apple.com", ListaConturi = new List<Cont>{
                    new Cont{ Id=102, IBAN="RO1711812623434573", Moneda = "RON", BancaId=1}
                } }

            }; 

            List<Factura> facturi = new List<Factura>{
                new Factura { Id = 1, Valoare = 2500, Moneda = "RON", DataEmitere = new DateTime(2020, 4, 3), DataScadenta = new DateTime(2020, 4, 30), FurnizorId = comapnii[1].Id, ClientId = comapnii[0].Id },
                new Factura { Id = 2, Valoare = 7300, Moneda = "RON", DataEmitere = new DateTime(2020, 1, 3), DataScadenta = new DateTime(2020, 5, 21), FurnizorId = comapnii[1].Id, ClientId = comapnii[0].Id },
                new Factura { Id = 3, Valoare = 1200, Moneda = "RON", DataEmitere = new DateTime(2020, 4, 15), DataScadenta = new DateTime(2020, 6, 12), FurnizorId = comapnii[2].Id, ClientId = comapnii[0].Id },
                new Factura { Id = 4, Valoare = 4531, Moneda = "RON", DataEmitere = new DateTime(2020, 2, 12), DataScadenta = new DateTime(2020, 3, 29), FurnizorId = comapnii[3].Id, ClientId = comapnii[0].Id },
                new Factura { Id = 5, Valoare = 414.2, Moneda = "RON", DataEmitere = new DateTime(2020, 4, 3), DataScadenta = new DateTime(2020, 4, 10), FurnizorId = comapnii[3].Id, ClientId = comapnii[0].Id },
                new Factura { Id = 6, Valoare = 15.9, Moneda = "EUR", DataEmitere = new DateTime(2020, 4, 3), DataScadenta = new DateTime(2020, 4, 10), FurnizorId = comapnii[3].Id, ClientId = comapnii[0].Id },
                new Factura { Id = 7, Valoare = 100.5, Moneda = "EUR", DataEmitere = new DateTime(2020, 4, 3), DataScadenta = new DateTime(2020, 4, 10), FurnizorId = comapnii[3].Id, ClientId = comapnii[0].Id }
            }; 

            {
                foreach (var e in context.Banci) context.Banci.Remove(e);
                foreach (var e in context.Companii) context.Companii.Remove(e);
                foreach (var e in context.Conturi) context.Conturi.Remove(e);
                foreach (var e in context.Costuri) context.Costuri.Remove(e);
                foreach (var e in context.Facturi) context.Facturi.Remove(e);
                foreach (var e in context.Operatiuni) context.Operatiuni.Remove(e);
                foreach (var e in context.Tranzactii) context.Tranzactii.Remove(e);
                context.SaveChanges();
            }

            context.Banci.AddOrUpdate(x => x.Id, banci.ToArray());
            context.Conturi.AddOrUpdate(x => x.Id, conturi.ToArray());
            
            //context.Operatiuni.AddOrUpdate(x => x.Id, operatiuni.ToArray());

            context.Companii.AddOrUpdate(x => x.Id, comapnii.ToArray());
            context.Facturi.AddOrUpdate(x => x.Id, facturi.ToArray());

            context.SaveChanges();
        }
    }
}
