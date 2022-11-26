# BlazorChatApplication
Blazor WebAssembly版チャットアプリ

## 開発フロー

1. Visual Studio Community 2022インストール
    * <details><summary>Visual Studio Installer最新ダウンロード</summary><div>
        https://aka.ms/vs/17/release/vs_community.exe</div></details>
    * ダウンロード先でコマンドプロンプトを管理者権限で実行
    * <details><summary>インストールのためコマンド実行</summary><div>
        vs_Community.exe --nocache --noUpdateInstaller --add Microsoft.VisualStudio.Workload.NetWeb --includeRecommended --includeOptional --quiet --norestart
        詳細：https://learn.microsoft.com/en-us/visualstudio/install/use-command-line-parameters-to-install-visual-studio?view=vs-2022
    * <details><summary>インストール時（2022/11/26）バージョン情報</summary><div>
        Microsoft Visual Studio Community 2022
        Version 17.4.1
        VisualStudio.17.Release/17.4.1+33110.190
        Microsoft .NET Framework
        Version 4.8.04084

        インストールされているバージョン:Community

        ASP.NET and Web Tools   17.4.326.54890
        ASP.NET and Web Tools

        Azure App Service Tools v3.0.0   17.4.326.54890
        Azure App Service Tools v3.0.0

        Azure Functions and Web Jobs Tools   17.4.326.54890
        Azure Functions and Web Jobs Tools

        C# ツール   4.4.0-6.22559.4+d7e8a398ef479a908e76bded82150c39251d0c9c
        IDE で使用する C# コンポーネント。プロジェクトの種類や設定に応じて、異なるバージョンのコンパイラを使用できます。

        Common Azure Tools   1.10
        Azure Mobile Services および Microsoft Azure Tools で使用する共通サービスを提供します。

        Microsoft JVM Debugger   1.0
        Provides support for connecting the Visual Studio debugger to JDWP compatible Java Virtual Machines

        NuGet パッケージ マネージャー   6.4.0
        Visual Studio 内の NuGet パッケージ マネージャー。NuGet の詳細については、https://docs.nuget.org/ にアクセスしてください

        Razor (ASP.NET Core)   17.0.0.2246202+61cc048d36a3fc9246d2f04625988b19a18ab8f0
        ASP.NET Core Razor の言語サービスを提供します。

        SQL Server Data Tools   17.0.62207.28050
        Microsoft SQL Server Data Tools

        TypeScript Tools   17.0.10921.2001
        TypeScript Tools for Microsoft Visual Studio

        Visual Basic ツール   4.4.0-6.22559.4+d7e8a398ef479a908e76bded82150c39251d0c9c
        IDE で使用する Visual Basic コンポーネント。プロジェクトの種類や設定に応じて、異なるバージョンのコンパイラを使用できます。

        Visual F# Tools   17.4.0-beta.22512.4+525d5109e389341bb90b144c24e2ad1ceec91e7b
        Microsoft Visual F# Tools

        Visual Studio IntelliCode   2.2
        Visual Studio 向けの AI 支援付き開発。
        </div></details>

1. ワークロード「ASP.NETとWeb開発」追加
   * 


