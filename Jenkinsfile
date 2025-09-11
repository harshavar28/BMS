pipeline {
    agent any

    environment {
        // Docker Hub credentials (configured in Jenkins)
        DOCKERHUB_CREDENTIALS = 'dockerhub-creds'   // Jenkins credentials ID
        DOCKERHUB_USERNAME = 'harshavar28'
        BACKEND_IMAGE = 'harshavar28/prj5-backend'
        FRONTEND_IMAGE = 'harshavar28/prj5-frontend'
    }

    stages {

        stage('Checkout') {
            steps {
                git 'https://github.com/your-username/your-repo.git'  // Replace with your repo
            }
        }

        stage('Build Docker Images') {
            steps {
                script {
                    def tag = "latest"  // You can change this to something like GIT_COMMIT

                    // Backend
                    sh """
                    docker build -t ${BACKEND_IMAGE}:${tag} -f BMSB/Dockerfile .
                    """

                    // Frontend
                    sh """
                    docker build -t ${FRONTEND_IMAGE}:${tag} -f BMSF/Dockerfile .
                    """
                }
            }
        }

        stage('Login to Docker Hub') {
            steps {
                script {
                    docker.withRegistry('', DOCKERHUB_CREDENTIALS) {
                        echo 'Logged in to Docker Hub'
                    }
                }
            }
        }

        stage('Push Images') {
            steps {
                script {
                    def tag = "latest"

                    sh "docker push ${BACKEND_IMAGE}:${tag}"
                    sh "docker push ${FRONTEND_IMAGE}:${tag}"
                }
            }
        }

    }

    post {
        always {
            echo 'Cleaning up...'
            sh 'docker image prune -f'
        }
    }
}
