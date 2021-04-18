using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAnts
{
    public class Output
    {
        double[][] townCoords;
        private double[][] d;
        private double[][] eta;

        private List<double[][]> tauAtTime;
        private List<int[][]> townAntsAtTime;
        private List<byte[][]> tabuAtTime;
        private byte[][] finalTabu;

        private List<byte[]> townsOfShortestTourAtCycle;
        private List<double> shortestTourAtCycle;

        private byte[] StaedteKuerzesterTourOfAll;
        private double kuerzesteTourOfAll;
        private double[][] finalTau;

        private double alpha, beta;

        private int timeEnd;

        public Output()
        {
            this.townCoords = null;
            this.d = null;
            this.eta = null;
            this.tauAtTime = new List<double[][]>();
            this.townAntsAtTime = new List<int[][]>();
            this.tabuAtTime = new List<byte[][]>();
            this.townsOfShortestTourAtCycle = new List<byte[]>();
            this.shortestTourAtCycle = new List<double>();
            this.StaedteKuerzesterTourOfAll = null;
            this.kuerzesteTourOfAll = 0;
            this.finalTau = null;
            this.timeEnd = 0;
            this.finalTabu = null;
            this.alpha = 1;
            this.beta = 1;
        }

        public List<double[][]> getTauVonT()
        {
            return this.tauAtTime;
        }
        public List<byte[]> getStaedteKuerzesterTourVonRunde()
        {
            return this.townsOfShortestTourAtCycle;
        }
        public List<double> getKuerzesteTourVonRunde()
        {
            return this.shortestTourAtCycle;
        }
        public byte[] getStaedteKuerzesterTourOfAll()
        {
            return this.StaedteKuerzesterTourOfAll;
        }
        public double getKuerzesteTourOfAll()
        {
            return this.kuerzesteTourOfAll;
        }
        public double[][] getD()
        {
            return this.d;
        }
        public double[][] getEta()
        {
            return this.eta;
        }
        public List<int[][]> getStadtAmeisenVonT()
        {
            return this.townAntsAtTime;
        }
        public List<byte[][]> getAmeisenTabulistenVonT()
        {
            return this.tabuAtTime;
        }
        public double[][] getStadtkoordinaten()
        {
            return this.townCoords;
        }
        public int getTimeEnd()
        {
            return this.timeEnd;
        }
        public byte[][] getFinalTabu()
        {
            return this.finalTabu;
        }
        public double getAlpha()
        {
            return this.alpha;
        }
        public double getBeta()
        {
            return this.beta;
        }
        public void setStadtkoordinaten(double[][] StadtKoordinaten)
        {
            this.townCoords = StadtKoordinaten;
        }
        public double[][] getFinalTau()
        {
            return this.finalTau;
        }
        public void setD(double[][] d)
        {
            this.d = d;
        }
        public void setEta(double[][] eta)
        {
            this.eta = eta;
        }
        public void setStaedteKuerzesterTourOfAll(byte[] StaedteKuerzesterTourOfAll)
        {
            this.StaedteKuerzesterTourOfAll = StaedteKuerzesterTourOfAll;
        }
        public void setKuerzesteTourOfAll(double kuerzesteTourOfAll)
        {
            this.kuerzesteTourOfAll = kuerzesteTourOfAll;
        }
        public void setFinalTau(double[][] finalTau)
        {
            this.finalTau = finalTau;
        }
        public void setTimeEnd(int time)
        {
            this.timeEnd = time;
        }
        public void setFinalTabu(byte[][] finalTabu)
        {
            this.finalTabu = finalTabu;
        }
        public void setAlpha(double alpha)
        {
            this.alpha = alpha;
        }
        public void setBeta(double beta)
        {
            this.beta = beta;
        }
    }
}
