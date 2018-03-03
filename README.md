# Couchbase.Net.StepByStep

A step-by-step walkthrough for creating a simple RESTful API using ASP.NET MVC Core and Couchbase.

## Prerequisites

- Visual Studio 2017 or Visual Studio Code
- Couchbase Server 5.0 or later with the "travel-sample" bucket installed

### Installing Couchbase Server on your OS

Simply [download the correct installer for your OS here](https://www.couchbase.com/downloads) and run the installer.

### Or, Run Couchbase Server In A Docker Container

```sh
docker run -d --name demo -p 8091-8094:8091-8094 -p 11210-11211:11210-11211 couchbase:enterprise-5.1.0
```

### Configuring Couchbase

1. After installation is complete, run through the setup wizard at (http://localhost:8091/)
2. Set the password to "password" (or update appsettings.json with the password you choose)
3. Once the wizard is complete, install the travel-sample bucket (http://localhost:8091/ui/index.html#!/settings/sampleBuckets)
4. Give the bucket a minute or two to populate with sample data

## Step-By-Step

Each step has a branch in the Git repo, follow the links to view in GitHub.

0. [Just a project](../../tree/step0)
1. [Couchbase bootstrapping and teardown](../../tree/step1)
2. [Get an airline](../../tree/step2)
3. [Update an airline](../../tree/step3)
4. [Create an airline](../../tree/step4)
5. [Delete an airline](../../tree/step5)
6. [Get a list of airlines](../../tree/step6)