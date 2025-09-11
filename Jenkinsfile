pipeline {
    agent any

    environment {
        DOCKERHUB_CREDENTIALS = credentials('dockerhub-creds')  
        DOCKERHUB_USER = 'harshavar28'
        FRONTEND_IMAGE = "${DOCKERHUB_USER}/prj5-frontend"
        BACKEND_IMAGE  = "${DOCKERHUB_USER}/prj5-backend"
    }

    stages {
        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        stage('Build Frontend Image') {
            steps {
                script {
                    sh 'docker build -t $FRONTEND_IMAGE -f BMSF/Dockerfile .'
                }
            }
        }

        stage('Build Backend Image') {
            steps {
                script {
                    sh 'docker build -t $BACKEND_IMAGE -f BMSB/Dockerfile .'
                }
            }
        }

        stage('Login to Docker Hub') {
            steps {
                script {
                    sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_USER --password-stdin'
                }
            }
        }

        stage('Push Images to Docker Hub') {
            steps {
                script {
                    sh 'docker push $FRONTEND_IMAGE'
                    sh 'docker push $BACKEND_IMAGE'
                }
            }
        }
    }

    post {
        always {
            sh 'docker logout'
        }
    }
}
