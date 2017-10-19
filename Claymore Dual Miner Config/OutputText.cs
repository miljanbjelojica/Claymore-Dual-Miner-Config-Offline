using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Claymore_Dual_Miner_Config
{
    class OutputText
    {
        string[] servers = new string[4] { "us-west1", "eu1", "eu2", "asia1" };

        //START BATCH FILE SINGLE MINING ONLY
        public void StartBatch(string claymorePath, string coinType, string altCoinType, string port, string altPort, string mainAddress, string altAddress, string compName, string email)
        {
            // WRITES THE START BATCH FILE
            if (coinType == "eth" | coinType == "etc")
            {
                using (StreamWriter outputStartFile = new StreamWriter(claymorePath + @"\start.bat"))
                {
                    outputStartFile.WriteLine(
                        "TIMEOUT /T 15" + Environment.NewLine +
                        " " + Environment.NewLine +
                        "setx GPU_FORCE_64BIT_PTR 0" + Environment.NewLine + 
                        "setx GPU_MAX_HEAP_SIZE 100" + Environment.NewLine +
                        "setx GPU_USE_SYNC_OBJECTS 1" + Environment.NewLine +
                        "setx GPU_MAX_ALLOC_PERCENT 100" + Environment.NewLine +
                        "setx GPU_SINGLE_ALLOC_PERCENT 100" + Environment.NewLine +
                        " " + Environment.NewLine +
                        "EthDcrMiner64.exe -epool " + coinType + "-us-east1.nanopool.org:" + port + " -ewal " + mainAddress + "." + compName + "/" + email + " -epsw x -mode 1 -ftime 10"
                        );
                }
            }
            
            if (altCoinType == "sia")
            {
                using (StreamWriter outputStartFile = new StreamWriter(claymorePath + @"\start.bat"))
                {
                    outputStartFile.WriteLine(
                        "TIMEOUT /T 15 " + Environment.NewLine +
                        " " + Environment.NewLine +
                        "setx GPU_FORCE_64BIT_PTR 0" + Environment.NewLine +
                        "setx GPU_MAX_HEAP_SIZE 100" + Environment.NewLine +
                        "setx GPU_USE_SYNC_OBJECTS 1" + Environment.NewLine +
                        "setx GPU_MAX_ALLOC_PERCENT 100" + Environment.NewLine +
                        "setx GPU_SINGLE_ALLOC_PERCENT 100" + Environment.NewLine +
                        " " + Environment.NewLine +
                        "EthDcrMiner64.exe -epool " + coinType + "-us-east1.nanopool.org:" + port + " -ewal " + mainAddress + "." + compName + "/" + email + 
                        " -epsw x -dcoin sia -dpool stratum+tcp://sia-us-east1.nanopool.org:" + altPort + " -dwal " + altAddress + "/" + compName + "/" + email + " -dpsw x -ftime 10"
                        );
                }
            }

            //if (altCoinType == "pasc")
            //{
            //    using (StreamWriter outputStartFile = new StreamWriter(claymorePath + @"\start.bat"))
            //    {
            //        outputStartFile.WriteLine(
            //            "TIMEOUT /T 15 " + Environment.NewLine +
            //            " " + Environment.NewLine +
            //            "setx GPU_FORCE_64BIT_PTR 0" + Environment.NewLine +
            //            "setx GPU_MAX_HEAP_SIZE 100" + Environment.NewLine +
            //            "setx GPU_USE_SYNC_OBJECTS 1" + Environment.NewLine +
            //            "setx GPU_MAX_ALLOC_PERCENT 100" + Environment.NewLine +
            //            "setx GPU_SINGLE_ALLOC_PERCENT 100" + Environment.NewLine +
            //            " " + Environment.NewLine +
            //            "EthDcrMiner64.exe -epool " + coinType + "-us-east1.nanopool.org:" + port + " -ewal " + mainAddress + "." + compName + "/" + email + 
            //            " -epsw x -dcoin pasc -dpool pasc-us-east.nanopool.org:15555 -dwal " + altAddress + "." + compName + "/" + email + " -dpsw x -mode 0 -ftime 10"
            //            );
            //    }
            //}
        }


        // CREATES EPOOL TEXT FILE
        public void ePoolTextFile(string claymorePath, string coinType, string port, string mainAddress, string compName, string email)
        {            
            using (StreamWriter outputTextFile = new StreamWriter(claymorePath + @"\epools.txt"))
            {             
                foreach (string server in servers)
                {
                    outputTextFile.WriteLine(
                        "POOL: " + coinType + "-" + server + ".nanopool.org:" + port + ", WALLET: " + mainAddress + "." + compName + "/" + email + ", PSW: x, WORKER: , ESM: 0, ALLPOOLS: 0"
                        );
                }
            }
        }

        // CREATES DPOOL TEXT FILE FOR SIA
        public void dPoolTextFileSIA(string claymorePath, string altPort, string altAddress, string mainAddress, string compName, string email)
        {
            using (StreamWriter outputTextFile = new StreamWriter(claymorePath + @"\dpools.txt"))
            {
                foreach (string server in servers)
                {
                    outputTextFile.WriteLine(
                        "POOL: stratum+tcp://sia-" + server + ".nanopool.org:" + altPort + ", WALLET: " + altAddress + "/" + compName + "/" + email + ", PSW: x, WORKER: , ESM: 0, ALLPOOLS: 0"
                        );
                }
            }
        }

        // CREATES DPOOL TEXT FILE FOR SIA
        public void dPoolPASC(string claymorePath, string altCoinType, string altPort, string mainAddress, string compName, string email)
        {
            using (StreamWriter outputTextFile = new StreamWriter(claymorePath + @"\dpools.txt"))
            {
                foreach (string server in servers)
                {
                    outputTextFile.WriteLine(
                        "POOL: " + altCoinType + "-" + server + ".nanopool.org:" + altPort + ", WALLET: " + mainAddress + "." + compName + "/" + email + ", PSW: x, WORKER: , ESM: 0, ALLPOOLS: 0"
                        );
                }
            }
        }
    }
}
