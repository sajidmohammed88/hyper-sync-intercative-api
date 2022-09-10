# Introduction 
HyperSync-Interactive is a comprehensive high performance and scalable REST API for trading solutions. 

# Getting Started
1.	**ClientId**, **Uid**, **Pwd**, **Mpin** and **client secret** are add in the ***args*** in the ***console project***(The main project for test)
2.	Http call use [**Flurl**](https://flurl.dev/), you should install the nugets ***Flurl*** and ***Flurl.Http***
3.  Flurl configued to use System.Text.Json in the class ***/Common/Utils/FlurlJsonSerializer***
4.  Maybe, you should to update ***NewtonSoft*** too.
3.	Auth api : https://hypersync.in/stackdocs/HSAUTH_OAUTH_1.0.6/
4.  Trade Api : https://hypersync.in/stackdocs/hs_interactive_2.20.4/

# Build and Test
1.	Test : No Unit test
2.  Build : In VS Right click and Build Solution.