using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipment_Rental_Application.Helpers
{
    public class Calculations
    {
        public int RentalPrice(string EquipmentType, int Duration)
        {
            int sum = 100;
            int PremiumDailyFee = 60;
            int RegularDailyFee = 40;

            switch (EquipmentType.Trim())
            {
                case "Heavy":
                    sum += Duration * PremiumDailyFee;
                    break;

                case "Regular":
                    if (Duration < 3)
                    {
                        sum += Duration * PremiumDailyFee;
                        break;
                    }
                    else
                    {
                        sum += 2 * PremiumDailyFee + (Duration - 2) * RegularDailyFee;
                        break;
                    }

                case "Specialized":
                    if (Duration < 4)
                    {
                        sum += Duration * PremiumDailyFee;
                        break;
                    }
                    else
                    {
                        sum += 3 * PremiumDailyFee + (Duration - 3) * RegularDailyFee;
                        break;
                    }
            }
            return sum;
        }
    }
}


