using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Windows;
using System.Windows.Ink;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string aux = "";
            IDictionary<string, Object> teste;
            teste = new Dictionary<string, Object>();
            teste.Add("nome1","valor0");
            teste.Add("size1", "valor1");
            teste.Add("size2", "valor2");

            Type custDataType = BuildDynamicTypeWithProperties(teste);

            PropertyInfo[] custDataPropInfo = custDataType.GetProperties();
            foreach (PropertyInfo pInfo in custDataPropInfo)
            {
                Console.WriteLine("Property '{0}' created!", pInfo.ToString());
            }

            Console.WriteLine("---");
            // Note that when invoking a property, you need to use the proper BindingFlags -
            // BindingFlags.SetProperty when you invoke the "set" behavior, and 
            // BindingFlags.GetProperty when you invoke the "get" behavior. Also note that
            // we invoke them based on the name we gave the property, as expected, and not
            // the name of the methods we bound to the specific property behaviors.

            object custData = Activator.CreateInstance(custDataType);
            custDataType.InvokeMember("CustomerName", BindingFlags.SetProperty,
                null, custData, new object[] { "Joe User" });
            Type x = custData.GetType();
            foreach (PropertyInfo i in x.GetProperties())
            {
                Console.WriteLine($"aaaa {i.Name}");
            }
          //  Console.WriteLine($"asssddd  x. {x.GetProperties()}");
            Console.WriteLine("The customerName field of instance custData has been set to '{0}'.",
                custDataType.InvokeMember("CustomerName", BindingFlags.GetProperty,
                    null, custData, new object[] { }));


            ;
        }


        public static Type BuildDynamicTypeWithProperties(IDictionary<string, Object> teste)
        {
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName myAsmName = new AssemblyName();
            myAsmName.Name = "MyDynamicAssembly";

            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName,
                                                            AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder myModBuilder =
                myAsmBuilder.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");

            TypeBuilder myTypeBuilder = myModBuilder.DefineType("CustomerData",
                                                            TypeAttributes.Public);
            /////////////////////////////////////




            foreach (KeyValuePair<string, Object> ax in teste)
            {
                Console.WriteLine($"ax {ax.Key} ");
           


            FieldBuilder customerNameBldr = myTypeBuilder.DefineField(ax.Key,
                                                            typeof(string),
                                                            FieldAttributes.Private);

            // The last argument of DefineProperty is null, because the
            // property has no parameters. (If you don't specify null, you must
            // specify an array of Type objects. For a parameterless property,
            // use an array with no elements: new Type[] {})
            PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty(ax.Key,
                                                             PropertyAttributes.HasDefault,
                                                             typeof(string),
                                                             null);




            MethodAttributes getSetAttr =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig;

            MethodBuilder custNameGetPropMthdBldr =
                myTypeBuilder.DefineMethod("get_"+ax.Key,
                                           getSetAttr,
                                           typeof(string),
                                           Type.EmptyTypes);

            ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();

            custNameGetIL.Emit(OpCodes.Ldarg_0);
            custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr);
            custNameGetIL.Emit(OpCodes.Ret);

            MethodBuilder custNameSetPropMthdBldr =
                myTypeBuilder.DefineMethod("set_"+ax.Key,
                                           getSetAttr,
                                           null,
                                           new Type[] { typeof(string) });

            ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();

            custNameSetIL.Emit(OpCodes.Ldarg_0);
            custNameSetIL.Emit(OpCodes.Ldarg_1);
            custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
            custNameSetIL.Emit(OpCodes.Ret);

            custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
            custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);

            }


            //////////////////////////////////

            //FieldBuilder customerNameBldr = myTypeBuilder.DefineField("customerName",
            //                                                typeof(string),
            //                                                FieldAttributes.Private);

            //// The last argument of DefineProperty is null, because the
            //// property has no parameters. (If you don't specify null, you must
            //// specify an array of Type objects. For a parameterless property,
            //// use an array with no elements: new Type[] {})
            //PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty("CustomerName",
            //                                                 PropertyAttributes.HasDefault,
            //                                                 typeof(string),
            //                                                 null);




            //MethodAttributes getSetAttr =
            //    MethodAttributes.Public | MethodAttributes.SpecialName |
            //        MethodAttributes.HideBySig;

            //MethodBuilder custNameGetPropMthdBldr =
            //    myTypeBuilder.DefineMethod("get_CustomerName",
            //                               getSetAttr,
            //                               typeof(string),
            //                               Type.EmptyTypes);

            //ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();

            //custNameGetIL.Emit(OpCodes.Ldarg_0);
            //custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr);
            //custNameGetIL.Emit(OpCodes.Ret);

            //MethodBuilder custNameSetPropMthdBldr =
            //    myTypeBuilder.DefineMethod("set_CustomerName",
            //                               getSetAttr,
            //                               null,
            //                               new Type[] { typeof(string) });

            //ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();

            //custNameSetIL.Emit(OpCodes.Ldarg_0);
            //custNameSetIL.Emit(OpCodes.Ldarg_1);
            //custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
            //custNameSetIL.Emit(OpCodes.Ret);

            //custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
            //custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);



            /////////////////////////////////////////////////////////////////////////








            //FieldBuilder customerSizeBldr = myTypeBuilder.DefineField("customerSize",
            //                                                typeof(string),
            //                                                FieldAttributes.Private);

            //// The last argument of DefineProperty is null, because the
            //// property has no parameters. (If you don't specify null, you must
            //// specify an array of Type objects. For a parameterless property,
            //// use an array with no elements: new Type[] {})
            //PropertyBuilder custSizePropBldr = myTypeBuilder.DefineProperty("customerSize",
            //                                                 PropertyAttributes.HasDefault,
            //                                                 typeof(string),
            //                                                 null);




            //MethodAttributes getSetAttrSize =
            //    MethodAttributes.Public | MethodAttributes.SpecialName |
            //        MethodAttributes.HideBySig;

            //MethodBuilder custSizeGetPropMthdBldr =
            //    myTypeBuilder.DefineMethod("get_CustomerSize",
            //                               getSetAttrSize,
            //                               typeof(string),
            //                               Type.EmptyTypes);

            //ILGenerator custSizeGetIL = custSizeGetPropMthdBldr.GetILGenerator();

            //custSizeGetIL.Emit(OpCodes.Ldarg_0);
            //custSizeGetIL.Emit(OpCodes.Ldfld, customerSizeBldr);
            //custSizeGetIL.Emit(OpCodes.Ret);

            //MethodBuilder custSizeSetPropMthdBldr =
            //    myTypeBuilder.DefineMethod("set_CustomerSize",
            //                                 getSetAttrSize,
            //                               null,
            //                               new Type[] { typeof(string) });

            //ILGenerator custSizeSetIL = custSizeSetPropMthdBldr.GetILGenerator();

            //custSizeSetIL.Emit(OpCodes.Ldarg_0);
            //custSizeSetIL.Emit(OpCodes.Ldarg_1);
            //custSizeSetIL.Emit(OpCodes.Stfld, customerSizeBldr);
            //custSizeSetIL.Emit(OpCodes.Ret);

            //custSizePropBldr.SetGetMethod(custSizeGetPropMthdBldr);
            //custSizePropBldr.SetSetMethod(custSizeSetPropMthdBldr);





            //////////////////////////////////////////////////////////////////////////////


            Type retval = myTypeBuilder.CreateType();

            // Save the assembly so it can be examined with Ildasm.exe,
            // or referenced by a test program.
            myAsmBuilder.Save(myAsmName.Name + ".dll");
            return retval;
        }
    }
}