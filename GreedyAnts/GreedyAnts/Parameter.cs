using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAnts
{
    public class Parameter
    {
        public enum typeOfAlgorithm // verschiedene Ameisenalgorithmen
        {
            Density,
            Quantity,
            Cycle
        }
        public enum typeOfSpreadTowns // verschiedene Verteilungen
        {
            Random,
            Custom,
            Undefined
        }
        public enum typeOfSpreadAnts
        {
            Even,
            Random,
            Custom
        }

        private bool isSelectedExample; // Beispiel
        private typeOfAlgorithm selectedAlgorithm;
        private int selectedAmountOfTowns; // Städte
        private typeOfSpreadTowns selectedSpreadTowns;
        private int selectedAmountOfAnts; // Ameisen
        private typeOfSpreadAnts selectedSpreadAnts;
        private double selectedStrength; // Pheromone
        private double selectedStartPheromone;
        private double selectedEvaporation;
        private double selectedWeightPheromone; // Gewichtung / Relative Bedeutung
        private double selectedWeightDistance;
        private int selectedAmountOfCycles; // Zyklen

        //Konstruktor
        public Parameter()
        {
        isSelectedExample = false;
        selectedAlgorithm = typeOfAlgorithm.Density;
        selectedAmountOfTowns = 0;
        selectedSpreadTowns = typeOfSpreadTowns.Random;
        selectedAmountOfAnts = 0;
        selectedSpreadAnts = typeOfSpreadAnts.Random;
        selectedStrength = 0;
        selectedStartPheromone = 0;
        selectedEvaporation = 0;
        selectedWeightPheromone = 0;
        selectedWeightDistance = 0;
        selectedAmountOfCycles = 0;
    }

        //Getter
        public bool getIsSelectedExample()
        {
            return this.isSelectedExample;
        }

        public typeOfAlgorithm getSelectedAlgorithm()
        {
            return this.selectedAlgorithm;
        }

        public int getSelectedAmountOfTowns()
        {
            return this.selectedAmountOfTowns;
        }

        public typeOfSpreadTowns getSelectedSpreadTowns()
        {
            return this.selectedSpreadTowns;
        }

        public int getSelectedAmountOfAnts()
        {
            return this.selectedAmountOfAnts;
        }

        public typeOfSpreadAnts getSelectedSpreadAnts()
        {
            return this.selectedSpreadAnts;
        }

        public double getSelectedStrength()
        {
            return this.selectedStrength;
        }

        public double getSelectedStartPheromone()
        {
            return this.selectedStartPheromone;
        }

        public double getSelectedEvaporation()
        {
            return this.selectedEvaporation;
        }

        public double getSelectedWeightPheromone()
        {
            return this.selectedWeightPheromone;
        }

        public double getSelectedWeightDistance()
        {
            return this.selectedWeightDistance;
        }

        public int getSelectedAmountOfCycles()
        {
            return this.selectedAmountOfCycles;
        }

        //Setter
        public void setIsSelectedExample(bool isExample)
        {
            this.isSelectedExample = isExample;
        }
        
        public void setSelectedAlgorithm(typeOfAlgorithm type)
        {
            this.selectedAlgorithm = type;
        }

        public void setSelectedAmountOfTowns(int amount)
        {
            this.selectedAmountOfTowns = amount;
        }

        public void setSelectedSpreadTowns(typeOfSpreadTowns type)
        {
            this.selectedSpreadTowns = type;
        }

        public void setSelectedAmountOfAnts(int amount)
        {
            this.selectedAmountOfAnts = amount;
        }

        public void setSelectedSpreadAnts(typeOfSpreadAnts type)
        {
            this.selectedSpreadAnts = type;
        }

        public void setSelectedStrength(double strength)
        {
            this.selectedStrength = strength;
        }

        public void setSelectedStartPheromone(double startPheromone)
        {
            this.selectedStartPheromone = startPheromone;
        }

        public void setSelectedEvaporation(double evaporation)
        {
            this.selectedEvaporation = evaporation;
        }

        public void setSelectedWeightPheromone(double weight)
        {
            this.selectedWeightPheromone = weight;
        }

        public void setSelectedWeightDistance(double weight)
        {
            this.selectedWeightDistance = weight;
        }

        public void setSelectedAmountOfCycles(int cycles)
        {
            this.selectedAmountOfCycles = cycles;
        }
    }
}
