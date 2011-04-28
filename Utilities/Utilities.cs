using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using System.IO;

namespace Utilities
{
    public static class Utilities
    {
        public static string UTF8String(string arg)
        {
            string retVal = arg;
            string geos = "აბგდევზთიკლმნოპჟრსტუფქღყშჩცძწჭხჯჰ";
            string engs = "abgdevzTiklmnopJrstufqRySCcZwWxjh";


            for (int i = 0; i < geos.ToCharArray().Length; i++)
            {
                retVal = retVal.Replace(engs.ToCharArray()[i], geos.ToCharArray()[i]);
            }

            return retVal;
        }

        public static string EngFromUTF8String(string arg)
        {
            string retVal = arg;
            string geos = "აბგდევზთიკლმნოპჟრსტუფქღყშჩცძწჭხჯჰ";
            string engs = "abgdevzTiklmnopJrstufqRySCcZwWxjh";


            for (int i = 0; i < engs.ToCharArray().Length; i++)
            {
                retVal = retVal.Replace(geos.ToCharArray()[i], engs.ToCharArray()[i]);
            }

            return retVal;
        }

        public static float ParseFloat(string arg)
        {
            float retVal = 0.0f;
            arg = arg.Replace(",", ".");

            System.Globalization.NumberFormatInfo float_fmt = new System.Globalization.NumberFormatInfo();
            float_fmt.NumberDecimalSeparator = ".";
            float_fmt.NumberGroupSeparator = "";
            try
            {
                retVal = Single.Parse(arg, float_fmt);
            }
            catch (FormatException)
            {
            }
            return retVal;
        }

        public static decimal ParseDecimal(string arg)
        {
            decimal retVal = 0.0m;
            arg = arg.Replace(",", ".");

            System.Globalization.NumberFormatInfo decimal_fmt = new System.Globalization.NumberFormatInfo();
            decimal_fmt.NumberDecimalSeparator = ".";
            decimal_fmt.NumberGroupSeparator = "";
            try
            {
                retVal = Decimal.Parse(arg, decimal_fmt);
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }
            return retVal;
        }
    }

    public static class Internals
    {

        public static string GetEnumValueDescription(object value)
        {
            // Get the type from the object.
            Type pobjType = value.GetType();

            // Get the member on the type that corresponds to the value passed in.
            FieldInfo pobjFieldInfo = pobjType.GetField(Enum.GetName(pobjType,
            value));

            // Now get the attribute on the field.
            DescriptionAttribute pobjAttribute = (DescriptionAttribute)
            (pobjFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);

            // Return the description.
            return pobjAttribute.Description;
        }
    }

    public static class Externals
    {
        public static info SaveCSV(string filename_arg, string data_arg)
        {
            info ret_info = info.niy();

            try
            {
                FileStream fs = File.Create(filename_arg, 1024, FileOptions.None);
                byte[] data = Encoding.Unicode.GetBytes(data_arg);
                //bom
                byte[] bom = Encoding.Unicode.GetPreamble();// {-17,-69,-65};
                //write bom
                fs.Write(bom, 0, bom.Length);
                //write data
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
            catch (IOException)
            {
                ret_info = new info("File cannot be written. Please check your drives and free space, or if the file is opened by Excel or another application. ", 1);
            }
            finally
            {
            }
            if (501 == ret_info.errcode)
            {
                ret_info = new info("File saved successfully. ", 0);
            }



            return ret_info;
        }
    }

    public class BackgroundWorker
    {
        Thread worker = new Thread(delegate() { });
        bool Busy = false;

        public bool Spawn(ThreadStart d)
        {
            if (!Busy)
            {
                try
                {
                    worker = new Thread(d);
                    worker.Start();
                }
                catch (Exception)
                {
                    Busy = false;
                    return false;
                }
                finally
                {
                    Busy = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    [XmlRootAttribute("Queue")]
    public class Queue
    {
        [XmlArray("Task")]
        private static List<Task> _TaskList = new List<Task>();

        public Queue()
        {
        }
        public static void AddTask(Task task_arg)
        {
            _TaskList.Add(task_arg);
        }
        public static void AddTaskRange(Task[] task_array_arg)
        {
            _TaskList.AddRange(task_array_arg);
        }
        public static List<Task> TaskList
        {
            get
            {
                return _TaskList;
            }
        }
    }

    [XmlRootAttribute("Task")]
    public class Task
    {
        [XmlAttribute]
        private DateTime _QueueTime = new DateTime();

        public info Execute()
        {
            Queue.AddTask(this);
            return new info("Added to Queue");
        }
    }

    public class info
    {
        public string details = "";
        public int errcode = 0;

        public info()
        {
            this.errcode = 0;
            this.details = "N/A";
        }
        public info(string info_arg)
        {
            this.details = info_arg;
            this.errcode = 0;
        }
        public info(string info_arg, int errcode_arg)
        {
            this.details = info_arg;
            this.errcode = errcode_arg;
        }

        public static info niy()
        {
            return new info("501 Not implemented yet", 501);
        }
    }
}
