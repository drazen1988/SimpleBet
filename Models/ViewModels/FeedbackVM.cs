
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class FeedbackVM
    {
        public FeedbackVM()
        {
            FeedbackDropDownList = new List<FeedbackDropDown>();
        }

        public List<FeedbackDropDown> FeedbackDropDownList { get; set; }

        [Required]
        public int? SelectedValue { get; set; }

        [Required]
        public string Description { get; set; }

        public List<FeedbackDropDown> InitializeDropDown()
        {
            List<FeedbackDropDown> list = new List<FeedbackDropDown> {
            new FeedbackDropDown(){ FeedbackTypeValue = 1, FeedbackTypeText = "Pohvala" },
            new FeedbackDropDown(){ FeedbackTypeValue = 2, FeedbackTypeText = "Sugestija" },
            new FeedbackDropDown(){ FeedbackTypeValue = 3, FeedbackTypeText = "Kritika" }
            };

            return list;
        }
    }

    public class FeedbackDropDown
    {
        public int? FeedbackTypeValue { get; set; }
        public string FeedbackTypeText { get; set; }
    }
}
