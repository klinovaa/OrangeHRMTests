pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }
    }
    post {
        always{
            allure includeProperties: false, jdk: '', results: [[path: 'OrangeHRM/bin/Debug/net6.0/allure-results']]
        }
    }
}
