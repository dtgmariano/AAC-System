﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAKeyboard.GeneticAlgorithm;
using GAKeyboard.Language;
using System.IO;

namespace GAKeyboard
{
    public class GALayoutGenerator
    {
        static bool hasRank = true;
        static int suggestionCriteriaNumber = 4;


        public GALayoutGenerator(Random _randomseed, string _filePath)
        {
            Dictionary myDictionary = new Dictionary(_filePath, hasRank, suggestionCriteriaNumber);
            var crossoverRate = 0.85;
            var mutationRate = 0.75;
            var numberOfGenerations = 100;
            var populationSize = 50;
            var elitismSize = 4;
            GA myGA = new GA(crossoverRate, mutationRate, numberOfGenerations, populationSize, elitismSize, myDictionary, _randomseed);
            //Exporter.exportData(myGA.bestPerGeneration);
            Exporter.saveEvolutionPerGeneration(myGA.bestPerGeneration, "EvolutionPerGeneration.txt");
            //Exporter.saveAleles(myGA.finalPopulation, "layouts.txt");
        }
    }

    public static class Exporter
    {
        public static void exportData(List<Chromossome> bestPerGeneration)
        {
            var o = new List<Chromossome>(bestPerGeneration);

            var firstGenKeyboard = o[0];
            var lastGenKeyboard = o[o.Count()-1];
            var bestKeyboard = o.OrderBy(p => p.fitness).ToList()[0];
            var worseKeyboard = o.OrderBy(p => p.fitness).ToList()[o.Count() - 1];

            var date = DateTime.Today.ToString();

            var outputFilePath1 = "firstGenKeyboard.txt";
            var outputFilePath2 = "lastGenKeyboard.txt";
            var outputFilePath3 = "bestKeyboard.txt";
            var outputFilePath4 = "worseKeyboard.txt";

            Exporter.saveFile(firstGenKeyboard, outputFilePath1);
            Exporter.saveFile(lastGenKeyboard, outputFilePath2);
            Exporter.saveFile(bestKeyboard, outputFilePath3);
            Exporter.saveFile(worseKeyboard, outputFilePath4);
        }

        public static bool saveFile(Chromossome kb, string outputFilePath)
        {
            bool hasSuccess = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(String.Join("", kb.aleles.ToArray()));

                    foreach(KeyValuePair<Word,double> kvp in kb.TableOfEffortToWriteADictionary)
                    {
                        writer.WriteLine(kvp.Key.rank + "\t" + kvp.Key.content + "\t" + kvp.Key.prefix + "\t" + kvp.Value);
                    }
                        
                }
                hasSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hasSuccess;
        }

        public static bool saveAleles(List<Chromossome> chromossomes, string outputFilePath)
        {
            bool hasSuccess = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (Chromossome c in chromossomes)
                    {
                        writer.WriteLine(String.Join("", c.aleles.ToArray()) + "\t" + c.fitness);
                    }

                } 
                hasSuccess = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }


            return hasSuccess;
        }

        public static bool saveEvolutionPerGeneration(List<Chromossome> chromossomes, string outputFilePath)
        {
            bool hasSuccess = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (Chromossome c in chromossomes)
                    {
                        writer.WriteLine(String.Join("", c.aleles.ToArray()) + "\t" + c.fitness);
                    }

                }
                hasSuccess = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return hasSuccess;
        }

    }
}
