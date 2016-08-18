<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RiotSharp;

namespace LoL_Helper
{
    public partial class Form1 : Form
    {
        string apiKey = System.IO.File.ReadAllText("apikey.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                getSummonerStats(summonerNameTextBox.Text);
            }
            catch {
                dataTextBox.Text = "Error: Please enter your summoner name and select a region.";
            }

        }
 
        private void getSummonerStats(string summonerName) {

            var regionNA = RiotSharp.Region.na;
            var regionEUW = RiotSharp.Region.euw;
            var regionEUNE = RiotSharp.Region.eune;
            var regionBR = RiotSharp.Region.br;
            var regionKR = RiotSharp.Region.kr;
            var regionLAN = RiotSharp.Region.lan;
            var regionLAS = RiotSharp.Region.las;
            var regionTR = RiotSharp.Region.tr;
            var regionRU = RiotSharp.Region.ru;
            var regionOCE = RiotSharp.Region.oce;

            try
            {
                string selectedRegion = regionComboBox.SelectedItem.ToString();

                switch (selectedRegion)
                {
                    case "NA":
                        getData(regionNA, summonerName);
                        break;
                    case "EUW":
                        getData(regionEUW, summonerName);
                        break;
                    case "EUNE":
                        getData(regionEUNE, summonerName);
                        break;
                    case "BR":
                        getData(regionBR, summonerName);
                        break;
                    case "OCE":
                        getData(regionOCE, summonerName);
                        break;
                    case "LAN":
                        getData(regionLAN, summonerName);
                        break;
                    case "LAS":
                        getData(regionLAS, summonerName);
                        break;
                    case "TR":
                        getData(regionTR, summonerName);
                        break;
                    case "RU":
                        getData(regionRU, summonerName);
                        break;
                    case "KR":
                        getData(regionKR, summonerName);
                        break;
                }

            }
            catch (RiotSharpException rsEX)
            {
                MessageBox.Show(rsEX.ToString());
            }
        }

        private void getData(RiotSharp.Region region, string summonerName) {
            var api = RiotApi.GetInstance(apiKey);

            statusLabel.Text = "Please wait...";
            dataTextBox.Clear();
            var getSummoner = api.GetSummoner(region, summonerName);

            if (getSummoner.Level.Equals(30))
            {
                List<RiotSharp.LeagueEndpoint.League> leagueData = getSummoner.GetLeagues();
                var league = leagueData[0].Tier.ToString();
                var division = leagueData[0].Entries[0].Division.ToString();
                var lp = leagueData[0].Entries[0].LeaguePoints.ToString();
                float wins = leagueData[0].Entries[0].Wins;
                float losses = leagueData[0].Entries[0].Losses;
                float games = wins + losses;
                float winLossRatio = wins / games * 100;

                dataTextBox.Text = "Summoner Name: " + getSummoner.Name +

                                "\nID: " + getSummoner.Id +
                                "\nLevel: " + getSummoner.Level +
                                "\nRevision Date: " + getSummoner.RevisionDate +
                                "\nRegion: " + getSummoner.Region +

                                "\n\nRanked Stats " +
                                "\nRank: " + league + " " + division +
                                "\nLP: " + lp +
                                "\nWins: " + wins +
                                "\nLosses: " + losses +
                                "\nTotal Games: " + games +
                                "\nW/L Ratio: " + winLossRatio + "%";
                statusLabel.Text = "Done.";
            }
            else
            {

                dataTextBox.Text = "Summoner Name: " + getSummoner.Name +

                                    "\nID: " + getSummoner.Id +
                                    "\nLevel: " + getSummoner.Level +
                                    "\nRevision Date: " + getSummoner.RevisionDate +
                                    "\nRegion: " + getSummoner.Region;

                statusLabel.Text = "Done.";
            }
        }
        
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RiotSharp;

namespace LoL_Helper
{
    public partial class Form1 : Form
    {
        string apiKey = System.IO.File.ReadAllText("apikey.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                getSummonerStats(summonerNameTextBox.Text);
            }
            catch {
                dataTextBox.Text = "Error: Please enter your summoner name and select a region.";
            }

        }
 
        private void getSummonerStats(string summonerName) {

            var regionNA = RiotSharp.Region.na;
            var regionEUW = RiotSharp.Region.euw;
            var regionEUNE = RiotSharp.Region.eune;
            var regionBR = RiotSharp.Region.br;
            var regionKR = RiotSharp.Region.kr;
            var regionLAN = RiotSharp.Region.lan;
            var regionLAS = RiotSharp.Region.las;
            var regionTR = RiotSharp.Region.tr;
            var regionRU = RiotSharp.Region.ru;
            var regionOCE = RiotSharp.Region.oce;

            try
            {
                string selectedRegion = regionComboBox.SelectedItem.ToString();

                switch (selectedRegion)
                {
                    case "NA":
                        getData(regionNA, summonerName);
                        break;
                    case "EUW":
                        getData(regionEUW, summonerName);
                        break;
                    case "EUNE":
                        getData(regionEUNE, summonerName);
                        break;
                    case "BR":
                        getData(regionBR, summonerName);
                        break;
                    case "OCE":
                        getData(regionOCE, summonerName);
                        break;
                    case "LAN":
                        getData(regionLAN, summonerName);
                        break;
                    case "LAS":
                        getData(regionLAS, summonerName);
                        break;
                    case "TR":
                        getData(regionTR, summonerName);
                        break;
                    case "RU":
                        getData(regionRU, summonerName);
                        break;
                    case "KR":
                        getData(regionKR, summonerName);
                        break;
                }

            }
            catch (RiotSharpException rsEX)
            {
                MessageBox.Show(rsEX.ToString());
            }
        }

        private void getData(RiotSharp.Region region, string summonerName) {
            var api = RiotApi.GetInstance(apiKey);

            statusLabel.Text = "Please wait...";
            dataTextBox.Clear();
            var getSummoner = api.GetSummoner(region, summonerName);

            if (getSummoner.Level.Equals(30))
            {
                List<RiotSharp.LeagueEndpoint.League> leagueData = getSummoner.GetLeagues();
                var league = leagueData[0].Tier.ToString();
                var division = leagueData[0].Entries[0].Division.ToString();
                var lp = leagueData[0].Entries[0].LeaguePoints.ToString();
                float wins = leagueData[0].Entries[0].Wins;
                float losses = leagueData[0].Entries[0].Losses;
                float games = wins + losses;
                float winLossRatio = wins / games * 100;

                dataTextBox.Text = "Summoner Name: " + getSummoner.Name +

                                "\nID: " + getSummoner.Id +
                                "\nLevel: " + getSummoner.Level +
                                "\nRevision Date: " + getSummoner.RevisionDate +
                                "\nRegion: " + getSummoner.Region +

                                "\n\nRanked Stats " +
                                "\nRank: " + league + " " + division +
                                "\nLP: " + lp +
                                "\nWins: " + wins +
                                "\nLosses: " + losses +
                                "\nTotal Games: " + games +
                                "\nW/L Ratio: " + winLossRatio + "%";
                statusLabel.Text = "Done.";
            }
            else
            {

                dataTextBox.Text = "Summoner Name: " + getSummoner.Name +

                                    "\nID: " + getSummoner.Id +
                                    "\nLevel: " + getSummoner.Level +
                                    "\nRevision Date: " + getSummoner.RevisionDate +
                                    "\nRegion: " + getSummoner.Region;

                statusLabel.Text = "Done.";
            }
        }
        
    }
}
>>>>>>> origin/master
