using TP9;

namespace TP9Test.Builders
{
    class ProduitTestBuilder
    {
        public ProduitTestBuilder()
        {
        }

        public Produit Builder()
        {
            return new Nourriture("Chips", 0.5m, 1.5m, 2);
        }

        public Produit ChipsBuilder()
        {
            return new Nourriture("Chips", 0.5m, 1.5m, 2);
        }

        public Produit CocaBuilder()
        {
            return new Boisson("Coca", 0.2m, 1, 2);
        }

        public Produit BiereBuilder()
        {
            return new BoissonAlcoolisee("Biere", 0.5m, 2, 3.5m, 5);
        }

        public Produit JambonBuilder()
        {
            return new Nourriture("Jambon", 0.5m, 2, 100);
        }
        public Produit TiramisuBuilder()
        {
            return new Nourriture("Tiramisu", 0.5m, 2, 2);
        }

        public Produit SaladeBuilder()
        {
            return new Nourriture("Salade", 0.1m, 0.5m, 1);
        }
        public Produit SandwichBuilder()
        {
            return new Nourriture("Sandwich", 1m, 1.5m, 2);
        }

        public Produit SandwichVegetarienBuilder()
        {
            return new Nourriture("Sandwich vege", 1m, 1.5m, 2);
        }
        public Produit GateauBuilder()
        {
            return new Nourriture("Gateau", 1m, 1.5m, 2);
        }
    }
}
