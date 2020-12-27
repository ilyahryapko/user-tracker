import React, { useEffect, useState } from 'react'
import logger from '../services/log.service';
import NavigationArea from './NavigationArea';
import Table from './Table'

export default function Logs() {
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await logger.getUserLogs();
      setLogs(result);
    }

    fetchData()
  }, []);

  const navigationLinks = [
    { path: '/', text: 'Root Page' },
    { path: '/second', text: 'Second Page' },
    { path: '/third', text: 'Third Page' },
    { path: '/logs/all', text: 'All Logs' }
  ]

  return (
    <div>
      <h1>Logs</h1>
      <NavigationArea links={navigationLinks}></NavigationArea>
      <Table data={logs}></Table>
    </div>
  )
}