using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Domain
{
    public class WeeklyReport
    {
        public int WeeklyReportId { get; set; }
        public int TeamMemberId { get; set; }
        public int MoraleLevel { get; set; }
        public string MoraleComment { get; set; }
        public int StressLevel { get; set; }
        public string StressComment { get; set; }
        public int WorkloadLevel { get; set; }
        public string WorkLoadComment { get; set; }
        public string WeeklyHigh {get; set;}
        public string WeeklyLow {get; set;}
        public string AnythingElse { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
       /* public WeeklyReport(
            int id,
            int teammemberid,
            int moralelevel,
            string moralecomment,
            int stresslevel,
            string stresscomment,
            int workloadlevel,
            string workloadcomment,
            string weeklyhigh,
            string weeklylow,
            string anythingelse,
            string datefrom,
            string dateto)
        {
            WeeklyReportId = id;
            TeamMemberId = teammemberid;
            MoraleLevel = moralelevel;
            MoraleComment = moralecomment;
            StressLevel = stresslevel;
            StressComment = stresscomment;
            WorkloadLevel = workloadlevel;
            WorkLoadComment = workloadcomment;
            WeeklyHigh = weeklyhigh;
            WeeklyLow = weeklylow;
            AnythingElse = anythingelse;
            DateFrom = datefrom;
            DateTo = dateto;

        }*/



    }
}
