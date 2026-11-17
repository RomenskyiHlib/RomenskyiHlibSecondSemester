using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLab
{
    public class Candidate : INotifyPropertyChanged, IEditableObject
    {
        private struct CandidateData {
            internal string FullName;
            internal int BirthYear;
            internal string Education;
            internal string ForeignLanguages;
            internal bool ComputerSkills;
            internal int ExperienceYears;
            internal bool Recommendations;
        }
        public Candidate() {
            FullName = "П.І.П.";
            BirthYear = 2000;
            Education = "Середня";
            ForeignLanguages = "Англійська";
            ComputerSkills = true;
            ExperienceYears = 1;
            Recommendations = true;
        }
        public Candidate(string fullName,int birth,string educ,string foreignLang,bool compSkill,int expYear,bool recommen) 
        { 
            FullName  = fullName;
            BirthYear = birth;
            Education = educ;
            ForeignLanguages = foreignLang;
            ComputerSkills = compSkill;
            ExperienceYears = expYear;
            Recommendations = recommen;
        }
        private CandidateData copyData;
        private CandidateData currentData;

        public string FullName
        {
            get { return currentData.FullName; }
            set { if (currentData.FullName != value)
                {
                    currentData.FullName = value;
                    NotifyPropertyChanged(nameof(FullName));
                }
            }
        }

        public int BirthYear
        {
            get { return currentData.BirthYear; }
            set { currentData.BirthYear = value;
                NotifyPropertyChanged(nameof(BirthYear));
            }
        }

        public string Education
        {
            get { return currentData.Education; }
            set { if (currentData.Education != value)
                {
                    currentData.Education = value;
                    NotifyPropertyChanged(nameof(Education));
                }
            }
        }

        public string ForeignLanguages
        {
            get { return currentData.ForeignLanguages; }
            set
            {
                if (currentData.ForeignLanguages != value)
                {
                    currentData.ForeignLanguages = value;
                    NotifyPropertyChanged(nameof(ForeignLanguages));
                }
            }
        }
       
        public bool ComputerSkills
        {
            get { return currentData.ComputerSkills; }
            set{ currentData.ComputerSkills = value;
                NotifyPropertyChanged(nameof(ComputerSkills));
            }
        }

        public int ExperienceYears
        {
            get { return currentData.ExperienceYears; }
            set { currentData.ExperienceYears = value;
                NotifyPropertyChanged(nameof(ExperienceYears));
            }
        }
        public bool Recommendations
        {
            get { return currentData.Recommendations; }
            set { currentData.Recommendations = value;
                NotifyPropertyChanged(nameof(Recommendations));
            }
        }

        public override string ToString()
        {
            return $"{FullName},{BirthYear},{Education},{ForeignLanguages},{ComputerSkills},{ExperienceYears},{Recommendations}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string infoAboutProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(infoAboutProperty));
        }

        public void BeginEdit()
        {
            copyData = currentData;
        }

        public void CancelEdit()
        {
            currentData = copyData;
            NotifyPropertyChanged("");
        }

        public void EndEdit()
        {
            copyData = new CandidateData();
        }
    }
}

