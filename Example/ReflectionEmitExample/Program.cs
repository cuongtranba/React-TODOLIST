using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Authentication.ExtendedProtection;

namespace ReflectionEmitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //RectangleClass();
            //AddMethod();
            //var a = ProxyGenerator.GetInterfaceProxy<User>();
            var a = ProxyGenerator.PropertyChangedProxy<User>();
            var user = new User();
            //var people = (People) user;
        }
        private static void RectangleClass()
        {
//Create assembly
            var moduleBuilder = GetAssemblyBuilder().DefineDynamicModule("RectangleTest");
            //Create type
            var typeBuilder = moduleBuilder.DefineType("Rectangle", TypeAttributes.Public);
            //Create field
            var lengthField = typeBuilder.DefineField("_length", typeof(Int32), FieldAttributes.PrivateScope);
            var widthField = typeBuilder.DefineField("_width", typeof(Int32), FieldAttributes.PrivateScope);
            //Create method
            MethodBuilder mCalArea = typeBuilder.DefineMethod("CalculateArea",
                MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.HasThis, typeof(Int32), null);

            ILGenerator ilGen = mCalArea.GetILGenerator();

            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, lengthField);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, widthField);
            ilGen.Emit(OpCodes.Mul);
            ilGen.Emit(OpCodes.Ret);


            PropertyBuilder lengthProperty =
                typeBuilder.DefineProperty("Length", PropertyAttributes.None, typeof(System.Int32), null);
            //lengthField getter
            var lengthFieldGetter = typeBuilder.DefineMethod("get_Length", MethodAttributes.Public, typeof(Int32),
                Type.EmptyTypes);
            ilGen = lengthFieldGetter.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, lengthField);
            ilGen.Emit(OpCodes.Ret);

            var lengthFieldSetter = typeBuilder.DefineMethod("set_Length", MethodAttributes.Public, null,
                new Type[] {typeof(System.Int32)});

            ilGen = lengthFieldSetter.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Stfld, lengthField);
            ilGen.Emit(OpCodes.Ret);
            lengthProperty.SetGetMethod(lengthFieldGetter);
            lengthProperty.SetGetMethod(lengthFieldSetter);

            PropertyBuilder widthProperty =
                typeBuilder.DefineProperty("Length", PropertyAttributes.None, typeof(System.Int32), null);
            //width getter
            var widthFieldGetter = typeBuilder.DefineMethod("get_width", MethodAttributes.Public, typeof(Int32),
                Type.EmptyTypes);
            ilGen = widthFieldGetter.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, widthField);
            ilGen.Emit(OpCodes.Ret);

            var widthFieldSetter = typeBuilder.DefineMethod("set_width", MethodAttributes.Public, null,
                new Type[] {typeof(System.Int32)});

            ilGen = widthFieldSetter.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Stfld, widthField);
            ilGen.Emit(OpCodes.Ret);

            widthProperty.SetGetMethod(lengthFieldGetter);
            widthProperty.SetGetMethod(lengthFieldSetter);

            //create contructor
            ConstructorBuilder conBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis,
                new Type[] {typeof(Int32), typeof(Int32)});

            ConstructorInfo conInfo = typeof(object).GetConstructor(new Type[] { });

            ilGen = conBuilder.GetILGenerator();

            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Call, conInfo);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Call, widthFieldSetter);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(OpCodes.Call, lengthFieldSetter);
            ilGen.Emit(OpCodes.Ret);

            ilGen = conBuilder.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Call, conBuilder);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Call, lengthFieldSetter);
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(OpCodes.Call, widthFieldSetter);
            ilGen.Emit(OpCodes.Ret);

            Console.WriteLine("Test the Rectangle class... ");

            var type = typeBuilder.CreateTypeInfo();
            object obj = Activator.CreateInstance(type.AsType(), 2, 3);
            object ret = type.GetDeclaredMethod("CalculateArea").Invoke(obj, null);

            Console.WriteLine("Area = " + ret);
            Console.Read();
        }

        private static void AddMethod()
        {
            var moduleBuilder = GetAssemblyBuilder().DefineDynamicModule("Calculator");
            var typeBuilder = moduleBuilder.DefineType("Add",TypeAttributes.Public);
            //create method
            var addMethod = typeBuilder.DefineMethod("AddValue",MethodAttributes.Public,typeof(void),null);
            
            var ilGen = addMethod.GetILGenerator();
            var a = ilGen.DeclareLocal(typeof(Int32));
            var b = ilGen.DeclareLocal(typeof(Int32));
            var c = ilGen.DeclareLocal(typeof(Int32));
            ilGen.Emit(OpCodes.Ldc_I4,5);
            ilGen.Emit(OpCodes.Stloc,a);
            ilGen.Emit(OpCodes.Ldc_I4,6);
            ilGen.Emit(OpCodes.Stloc,b);
            ilGen.Emit(OpCodes.Ldloc,a);
            ilGen.Emit(OpCodes.Ldloc,b);
            ilGen.Emit(OpCodes.Add);
            ilGen.Emit(OpCodes.Stloc, c);
            ilGen.EmitWriteLine(c);
            ilGen.Emit(OpCodes.Ret);
            Console.WriteLine("Test the add values... ");
            var type = typeBuilder.CreateTypeInfo();
            object obj = Activator.CreateInstance(type.AsType());
            object ret = type.GetDeclaredMethod("AddValue").Invoke(obj, null);
        }

        public static AssemblyBuilder GetAssemblyBuilder()
        {
            var builder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()),
                AssemblyBuilderAccess.Run);
            return builder;
        }
    }

    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Persion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
//static void add()
//{
//    int value1 = 10;
//    int value2 = 20;
//    int value3 = value1 + value2;
//}