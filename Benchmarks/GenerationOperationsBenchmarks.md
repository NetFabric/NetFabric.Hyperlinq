## GenerationOperationsBenchmarks

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
|           Method | Categories | Count |          Mean |       Error |      StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |----------- |------ |--------------:|------------:|------------:|------:|-------:|------:|------:|----------:|
|       Linq_Range |      Range | 10000 | 42,517.686 ns | 317.2573 ns | 296.7627 ns |  1.00 |      - |     - |     - |      40 B |
|  Hyperlinq_Range |      Range | 10000 |  2,712.916 ns |  29.3118 ns |  27.4183 ns |  0.06 |      - |     - |     - |         - |
|                  |            |       |               |             |             |       |        |       |       |           |
|      Linq_Repeat |     Repeat | 10000 | 37,102.863 ns | 315.2140 ns | 279.4290 ns |  1.00 |      - |     - |     - |      32 B |
|        Ix_Repeat |     Repeat | 10000 | 44,842.655 ns | 232.8893 ns | 206.4503 ns |  1.21 |      - |     - |     - |      40 B |
| Hyperlinq_Repeat |     Repeat | 10000 | 12,887.564 ns |  48.1255 ns |  42.6620 ns |  0.35 |      - |     - |     - |         - |
|                  |            |       |               |             |             |       |        |       |       |           |
|        Ix_Return |     Return | 10000 |     24.216 ns |   0.2081 ns |   0.1738 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Return |     Return | 10000 |      5.529 ns |   0.0337 ns |   0.0299 ns |  0.23 |      - |     - |     - |         - |
|                  |            |       |               |             |             |       |        |       |       |           |
|        Ix_Create |     Create | 10000 | 62,667.977 ns | 415.0323 ns | 388.2215 ns |  1.00 |      - |     - |     - |     112 B |
| Hyperlinq_Create |     Create | 10000 | 13,713.148 ns |  73.2025 ns |  68.4737 ns |  0.22 | 0.0305 |     - |     - |      64 B |
