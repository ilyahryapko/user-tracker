import React, { useEffect, useState } from 'react'
import logger from '../services/log.service';
import NavigationArea from './NavigationArea';
import Table from './Table'

export default function LogsAll() {
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await logger.getAllLogs();
      setLogs(result);
    }

    fetchData()
  }, []);

  const navigationLinks = [
    { path: '/', text: 'Root Page' },
    { path: '/second', text: 'Second Page' },
    { path: '/third', text: 'Third Page' },
    { path: '/logs', text: 'Logs Page' }
  ]

  return (
    <div>
      <h1>Logs</h1>
      <NavigationArea links={navigationLinks}></NavigationArea>
      <Table data={logs}></Table>
    </div>
  )
}