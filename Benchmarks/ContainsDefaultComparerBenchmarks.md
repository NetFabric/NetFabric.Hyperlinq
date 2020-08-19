## ContainsDefaultComparerBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |           Categories | Count |       Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 579.540 ns | 4.8225 ns | 4.5110 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_Array |                Array |   100 |  75.852 ns | 0.3578 ns | 0.3347 ns |  0.13 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |  70.475 ns | 0.2856 ns | 0.2532 ns |  0.12 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  77.764 ns | 0.3967 ns | 0.3711 ns |  0.13 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 792.991 ns | 2.0800 ns | 1.9457 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 200.049 ns | 0.9095 ns | 0.8062 ns |  0.25 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 754.496 ns | 3.3814 ns | 2.9975 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 227.622 ns | 0.5457 ns | 0.4557 ns |  0.30 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 763.778 ns | 2.4008 ns | 2.1282 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|           Hyperlinq_List_Value |           List_Value |   100 |  10.367 ns | 0.0465 ns | 0.0389 ns |  0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 634.398 ns | 3.2997 ns | 3.0865 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 607.194 ns | 2.5773 ns | 2.2847 ns |  0.96 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |            |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 550.154 ns | 3.3569 ns | 2.9758 ns |  1.00 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   7.846 ns | 0.0208 ns | 0.0162 ns |  0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 571.013 ns | 2.7169 ns | 2.5414 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |  10.547 ns | 0.0894 ns | 0.0792 ns |  0.02 |      - |     - |     - |         - |
