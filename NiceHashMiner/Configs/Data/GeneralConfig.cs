using NiceHashMiner.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NiceHashMiner.Configs.Data {
    [Serializable]
    public class GeneralConfig {

        public Version ConfigFileVersion;
        public LanguageType Language = LanguageType.En;
        public string DisplayCurrency = "GBP";

        public bool DebugConsole = false;
        public string BitcoinAddress = "18Lmq3vwAC5RG8W6DWV8uVDr2Mu5paaHCm";
        public string WorkerName = "NC1";
        public TimeUnitType TimeUnit = TimeUnitType.Day;
        public string IFTTTKey = "";
        public int ServiceLocation = 0;
        public bool AutoStartMining = true;
        public bool HideMiningWindows = true;
        public bool MinimizeToTray = true;
        public bool MinimizeMiningWindows = false;
        //public int LessThreads;
        public CPUExtensionType ForceCPUExtension = CPUExtensionType.Automatic;

        public int SwitchMinSecondsFixed = 90;
        public int SwitchMinSecondsDynamic = 30;
        public int SwitchMinSecondsAMD = 60;
        public double SwitchProfitabilityThreshold = 0.07; // percent
        public int MinerAPIQueryInterval = 5;
        public int MinerRestartDelayMS = 500;

        public BenchmarkTimeLimitsConfig BenchmarkTimeLimits = new BenchmarkTimeLimitsConfig();
        // TODO deprecate this
        public DeviceDetectionConfig DeviceDetection = new DeviceDetectionConfig();

        public bool DisableAMDTempControl = true;
        public bool DisableDefaultOptimizations = false;

        public bool AutoScaleBTCValues = true;
        public bool StartMiningWhenIdle = true;

        public int MinIdleSeconds = 60;
        public bool LogToFile = true;

        // in bytes
        public long LogMaxFileSize = 1048576;

        public bool ShowDriverVersionWarning = false;
        public bool DisableWindowsErrorReporting = true;
        public bool ShowInternetConnectionWarning = false;
        public bool NVIDIAP0State = false;

        public int ethminerDefaultBlockHeight = 2000000;
        public DagGenerationType EthminerDagGenerationType = DagGenerationType.SingleKeep;
        public int ApiBindPortPoolStart = 5100;
        public double MinimumProfit = 0;
        public bool IdleWhenNoInternetAccess = true;
        public bool UseIFTTT = false;
        public bool DownloadInit = true;
        public bool RunScriptOnCUDA_GPU_Lost = true;
        // 3rd party miners
        public Use3rdPartyMiners Use3rdPartyMiners = Use3rdPartyMiners.NOT_SET;
        public bool DownloadInit3rdParty = true;

        public bool AllowMultipleInstances = true;

        // device enabled disabled stuff
        public List<ComputeDeviceConfig> LastDevicesSettup = new List<ComputeDeviceConfig>();
        // 
        public string hwid = "";
        public int agreedWithTOS = 1;

        // normalization stuff
        public double IQROverFactor = 3.0;
        public int NormalizedProfitHistory = 15;
        public double IQRNormalizeFactor = 0.0;

        public bool CoolDownCheckEnabled = true;

        // methods
        public void SetDefaults() {
            ConfigFileVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Language = LanguageType.En;
            ForceCPUExtension = CPUExtensionType.Automatic;
            BitcoinAddress = "18Lmq3vwAC5RG8W6DWV8uVDr2Mu5paaHCm";
            WorkerName = "NC1";
            TimeUnit = TimeUnitType.Day;
            ServiceLocation = 0;
            AutoStartMining = false;
            //LessThreads = 0;
            DebugConsole = false;
            HideMiningWindows = true;
            MinimizeToTray = true;
            BenchmarkTimeLimits = new BenchmarkTimeLimitsConfig();
            DeviceDetection = new DeviceDetectionConfig();
            DisableAMDTempControl = true;
            DisableDefaultOptimizations = false;
            AutoScaleBTCValues = true;
            StartMiningWhenIdle = true;
            LogToFile = true;
            LogMaxFileSize = 1048576;
            ShowDriverVersionWarning = true;
            DisableWindowsErrorReporting = true;
            ShowInternetConnectionWarning = true;
            NVIDIAP0State = false;
            MinerRestartDelayMS = 500;
            ethminerDefaultBlockHeight = 2000000;
            SwitchMinSecondsFixed = 90;
            SwitchMinSecondsDynamic = 30;
            SwitchMinSecondsAMD = 90;
            SwitchProfitabilityThreshold = 0.07; // percent
            MinIdleSeconds = 60;
            DisplayCurrency = "GBP";
            ApiBindPortPoolStart = 4000;
            MinimumProfit = 0;
            EthminerDagGenerationType = DagGenerationType.Parallel;
            DownloadInit = true;
            //ContinueMiningIfNoInternetAccess = false;
            IdleWhenNoInternetAccess = true;
            Use3rdPartyMiners = Use3rdPartyMiners.NOT_SET;
            DownloadInit3rdParty = true;
            AllowMultipleInstances = true;
            UseIFTTT = false;
            IQROverFactor = 3.0;
            NormalizedProfitHistory = 15;
            IQRNormalizeFactor = 0.0;
            CoolDownCheckEnabled = true;
            RunScriptOnCUDA_GPU_Lost = true;
        }

        public void FixSettingBounds() {
            this.ConfigFileVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (string.IsNullOrEmpty(this.DisplayCurrency)
                || String.IsNullOrWhiteSpace(this.DisplayCurrency)) {
                this.DisplayCurrency = "GBP";
            }
            if (this.SwitchMinSecondsFixed <= 0) {
                this.SwitchMinSecondsFixed = 90;
            }
            if (this.SwitchMinSecondsDynamic <= 0) {
                this.SwitchMinSecondsDynamic = 30;
            }
            if (this.SwitchMinSecondsAMD <= 0) {
                this.SwitchMinSecondsAMD = 60;
            }
            if (this.MinerAPIQueryInterval <= 0) {
                this.MinerAPIQueryInterval = 5;
            }
            if (this.MinerRestartDelayMS <= 0) {
                this.MinerRestartDelayMS = 500;
            }
            if (this.MinIdleSeconds <= 0) {
                this.MinIdleSeconds = 60;
            }
            if (this.LogMaxFileSize <= 0) {
                this.LogMaxFileSize = 1048576;
            }
            // check port start number, leave about 2000 ports pool size, huge yea!
            if (this.ApiBindPortPoolStart > (65535 - 2000)) {
                this.ApiBindPortPoolStart = 5100;
            }
            if (this.BenchmarkTimeLimits == null) {
                this.BenchmarkTimeLimits = new BenchmarkTimeLimitsConfig();
            }
            if (this.DeviceDetection == null) {
                this.DeviceDetection = new DeviceDetectionConfig();
            }
            if (this.LastDevicesSettup == null) {
                this.LastDevicesSettup = new List<ComputeDeviceConfig>();
            }
            if (IQROverFactor < 0) {
                IQROverFactor = 3.0;
            }
            if (NormalizedProfitHistory < 0) {
                NormalizedProfitHistory = 15;
            }
            if (IQRNormalizeFactor < 0) {
                IQRNormalizeFactor = 0.0;
            }
        }

    }
}
