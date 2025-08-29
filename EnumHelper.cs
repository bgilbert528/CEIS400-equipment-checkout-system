using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This class is used to help insert the Enum choices into comboBoxes
// maintaining data integrity from both front and back ends. Also
// keeps the code cleaner, modular, and reuseable.
// These will be called under the Main Form class for the program
// at Initialization.

namespace CEIS400_ECS
{
    public static class EnumHelper
    {
        // Get a list of EnumItem<T> from an enum type
        public static List<EnumItem<T>> GetEnumItems<T>() where T : Enum
        {
            var type = typeof(T);
            var list = new List<EnumItem<T>>();

            foreach (var value in Enum.GetValues(type).Cast<T>())
            {
                string description = value.ToString();
                var memInfo = type.GetMember(value.ToString());
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }

                list.Add(new EnumItem<T>
                {
                    Value = value,
                    Description = description
                });
            }

            return list;
        }

        // Bind enum to ComboBox using Description as display
        public static void BindToComboBox<T>(ComboBox comboBox) where T : Enum
        {
            comboBox.DataSource = GetEnumItems<T>();
            comboBox.DisplayMember = "Description";  // fixed typo
            comboBox.ValueMember = "Value";
        }
    }

    public class EnumItem<T>
    {
        public T Value { get; set; }
        public string Description { get; set; }

        public override string ToString() => Description;
    }
}
