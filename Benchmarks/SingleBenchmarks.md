## SingleBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                         Method |           Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array | 11.856 ns | 0.1299 ns | 0.1152 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                Array |  4.254 ns | 0.0263 ns | 0.0246 ns |  0.36 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |  6.500 ns | 0.0746 ns | 0.0698 ns |  0.55 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |  8.203 ns | 0.0365 ns | 0.0305 ns |  0.69 |      - |     - |     - |         - |
|                                |                      |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value | 40.716 ns | 0.2155 ns | 0.2016 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value | 16.745 ns | 0.0835 ns | 0.0781 ns |  0.41 |      - |     - |     - |         - |
|                                |                      |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value | 20.128 ns | 0.1103 ns | 0.0978 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value | 18.120 ns | 0.1700 ns | 0.1590 ns |  0.90 |      - |     - |     - |         - |
|                                |                      |           |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |  6.253 ns | 0.0383 ns | 0.0320 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |           List_Value |  7.304 ns | 0.0380 ns | 0.0318 ns |  1.17 |      - |     - |     - |         - |
|                                |                      |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference | 24.152 ns | 0.1150 ns | 0.0961 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference | 21.626 ns | 0.1007 ns | 0.0841 ns |  0.90 | 0.0191 |     - |     - |      40 B |
|                                |                      |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference | 16.639 ns | 0.1092 ns | 0.1022 ns |  1.00 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference | 16.333 ns | 0.0815 ns | 0.0763 ns |  0.98 | 0.0115 |     - |     - |      24 B |
|                                |                      |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |  6.222 ns | 0.0388 ns | 0.0344 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |       List_Reference |  7.344 ns | 0.0505 ns | 0.0447 ns |  1.18 |      - |     - |     - |         - |
