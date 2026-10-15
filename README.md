# OmegaSolider

Protobuf v1.1.0 contracts used by [Mamtzetza](https://github.com/eldarush/Mamtzetza) and its [QaaS suite](https://github.com/eldarush/mamtzetza-qaas-tests). The authoritative schema is [Protos/omega.proto](Protos/omega.proto).

## Published wire contract

Both messages share tags 1–12. Mamtzetza preserves these fields exactly.

| Tag | Field | Protobuf type |
|---|---|---|
| 1 | soldier_id | string |
| 2 | name | string |
| 3 | rank | string |
| 4 | age | int32 |
| 5 | favorite_food | string |
| 6 | favorite_tv_show | string |
| 7 | shoe_size | float |
| 8 | height | float |
| 9 | weight | float |
| 10 | lucky_number | int32 |
| 11 | hobby | string |
| 12 | origin_planet | string |

`FireflyExpert` additionally contains:

| Tag | Field | Protobuf type |
|---|---|---|
| 13 | favorite_technology | string |
| 14 | favorite_team | string |
| 15 | favorite_commander | string |
| 16 | favorite_woman | string |
| 17 | favorite_coding_language | string |
| 18 | glow_intensity | int32 |
| 19 | comedic_buff | string |
| 20 | processed_at_unix_ms | int64 |

The timestamp is UTC Unix epoch milliseconds. `lucky_number` supports the complete signed int32 domain. Proto3 scalar defaults are valid wire data; deserialization alone does not prove domain correctness. Use independent semantic assertions as well.

Never renumber, remove, change the type of, or reuse published tags. Reserve removed names/tags if a future reviewed migration requires removal. This onboarding update changes comments and documentation only; it does not change wire fields or publish a package.

## Build and verify

Install .NET SDK **10.0.203** (`global.json`). From this directory:

```powershell
dotnet restore tests/OmegaSolider.ContractTests/OmegaSolider.ContractTests.csproj
dotnet build -c Release --no-restore
dotnet test tests/OmegaSolider.ContractTests/OmegaSolider.ContractTests.csproj -c Release --no-restore
```

Contract regressions lock every published field name, number and type and check unknown-field round trips. Build generates a local v1.1.0 package; do not publish a changed package under an existing version. A future contract release requires a reviewed version bump and downstream restore/build/test in Mamtzetza and its QaaS suite.
