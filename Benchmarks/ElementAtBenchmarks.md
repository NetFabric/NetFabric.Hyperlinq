## ElementAtBenchmarks

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
|                     Linq_Array |                Array |   100 |  23.038 ns | 0.1502 ns | 0.1332 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                Array |   100 |   4.544 ns | 0.0416 ns | 0.0389 ns |  0.20 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |   4.254 ns | 0.0526 ns | 0.0492 ns |  0.18 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |   5.844 ns | 0.0182 ns | 0.0170 ns |  0.25 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 339.277 ns | 1.2194 ns | 1.0182 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 154.786 ns | 0.8735 ns | 0.8171 ns |  0.46 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 338.865 ns | 2.1237 ns | 1.8826 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 157.897 ns | 0.7533 ns | 0.7046 ns |  0.47 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 |   8.931 ns | 0.0627 ns | 0.0586 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |           List_Value |   100 |   6.056 ns | 0.0679 ns | 0.0635 ns |  0.68 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 343.927 ns | 1.9491 ns | 1.7279 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 288.318 ns | 1.2500 ns | 1.1693 ns |  0.84 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |            |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 238.366 ns | 1.7805 ns | 1.6655 ns |  1.00 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 255.678 ns | 1.3560 ns | 1.2684 ns |  1.07 | 0.0114 |     - |     - |      24 B |
|                                |                      |       |            |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   8.680 ns | 0.0473 ns | 0.0419 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   5.984 ns | 0.0260 ns | 0.0231 ns |  0.69 |      - |     - |     - |         - |
