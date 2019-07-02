using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PrototypeGuiCompositor30.DataModels;
using PrototypeGuiCompositor30.elements;
using WPG.Data;

namespace PrototypeGuiCompositor30.Manager
{
    public static class InstersecElementManager
    {

        public static dynamic IntersectProperties = new ExpandoObject() as IDictionary<string, Object>;

        public static void update()
        {

            dynamic IntersectPropertiesAux = new ExpandoObject() as IDictionary<string, Object>;

            IntersectPropertiesAux.teste = "batata";


            IntersectPropertiesAux = new ExpandoObject() as IDictionary<string, Object>;
            IntersectProperties = new ExpandoObject() as IDictionary<string, Object>;
            Type t = typeof(ElementContentDataModel);


            //// insere no IntersectPropertiesAux todas as propriedades em comum
            foreach (PropertyInfo i in t.GetProperties())
            {
                bool allHave = true;
                foreach (SimpleTextImageElement st in ProgramManager.ActiveScreen.Screen.Elements)
                    if (st.CanvasContetControlInstance.IsSelectedCCC)
                    {
                        Type aux = st.elementData.GetType();
                        if (aux.GetProperty(i.Name) == null)
                            allHave = false;
                    }

            if (allHave = true)
                    ((IDictionary<string, Object>)IntersectPropertiesAux).Add(i.Name, null);
                
            }


            //// insere no IntersectProperties todas os valores de prop que são iguais entres os elementos
            foreach (String i in ((IDictionary<string, Object>)IntersectPropertiesAux).Keys)
            {
                ((IDictionary<string, Object>)IntersectProperties).Add(i, null);
                Object defaultValue = new Object();
                int count = 0;
                bool isEqual = true;
              
                foreach (SimpleTextImageElement st in ProgramManager.ActiveScreen.Screen.Elements)
                    if (st.CanvasContetControlInstance.IsSelectedCCC)
                        if (count==0)
                        {
                            defaultValue = st.elementData.GetType().GetProperty(i).GetValue(st.elementData, null);
                            count = 1;
                        }
                        else
                            if (defaultValue != null && st.elementData.GetType().GetProperty(i).GetValue(st.elementData, null) != null)
                            {
                                if (defaultValue.ToString() != st.elementData.GetType().GetProperty(i).GetValue(st.elementData, null).ToString())
                                    isEqual = false;
                                
                            }
                            else
                                 if (defaultValue != st.elementData.GetType().GetProperty(i).GetValue(st.elementData, null))
                                     isEqual = false;
                                 
                        

                if (isEqual == true)
                    ((IDictionary<string, Object>) IntersectProperties)[i] = defaultValue;
                

            }
            print();
            ProgramManager.ActiveScreen.Screen.IntersectedProps = IntersectProperties;
            ProgramManager.uptadePropertyGrid();
        }

        private static void print()
        {
            Console.WriteLine("#### start show Intersected prop #####");
            foreach (String i in ((IDictionary<string, Object>)IntersectProperties).Keys)
                Console.WriteLine($" {i} { ((IDictionary<string, Object>)IntersectProperties)[i] }");

        }
        public static void printPublic()
        {
            Console.WriteLine("#### start show2 Intersected prop #####");
            foreach (String i in ((IDictionary<string, Object>)IntersectProperties).Keys)
                Console.WriteLine($" {i} { ((IDictionary<string, Object>)IntersectProperties)[i] }");

        }
    }
}
