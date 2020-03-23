pipeline {
    agent any 
    stages {
        stage('Build') {
            steps {
                echo 'Build Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/Sample.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/Sample.sln\""
                echo 'Build Ends'
            }
        }
		
		stage('Test') {
            steps {
                echo 'Test Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/Sample\""
                echo 'Test Ends'
            }
        }
		
		stage('Deploy') {
            steps {
                echo 'Deploy Starts!'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish \"${workspace}/Sample\" --output \"C:/tmp/dotnetweb\""
                echo 'Deploy Ends'
            }
        }		
    }
}