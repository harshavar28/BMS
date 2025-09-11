pipeline {
    agent any

    environment {
        DOCKER_HUB_CREDENTIALS = credentials('dockerhub-creds') // Add this in Jenkins Credentials
        BACKEND_IMAGE = 'harshavar28/prj5-backend'
        FRONTEND_IMAGE = 'harshavar28/prj5-frontend'
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/harshavar28/BMS'
            }
        }

        stage('Build Backend') {
            steps {
                script {
                    sh 'docker build -t $BACKEND_IMAGE -f BMSB/Dockerfile .'
                }
            }
        }

        stage('Build Frontend') {
            steps {
                script {
                    sh 'docker build -t $FRONTEND_IMAGE -f BMSF/Dockerfile .'
                }
            }
        }

        stage('Login to Docker Hub') {
            steps {
                script {
                    sh "echo $DOCKER_HUB_CREDENTIALS_PSW | docker login -u $DOCKER_HUB_CREDENTIALS_USR --password-stdin"
                }
            }
        }

        stage('Push Images') {
            steps {
                sh 'docker push $BACKEND_IMAGE'
                sh 'docker push $FRONTEND_IMAGE'
            }
        }
    }
}
