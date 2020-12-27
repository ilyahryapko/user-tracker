import api from './api.service';

const getUserLogs = () => {
  return api.get('logs');
}

const getAllLogs = () => {
  return api.get('logs/all')
}

const postLog = (data) => {
  return api.post('logs', data);
}

const sendLog = (fromPage, toPage) => {
  return postLog({
    currentPage: fromPage,
    nextPage: toPage
  })
}

const logger = {
  getUserLogs,
  getAllLogs,
  sendLog
}

export default logger;