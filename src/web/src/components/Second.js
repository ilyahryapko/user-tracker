import React from 'react'
import LoremText from './LoremText'
import NavigationArea from './NavigationArea'

export default function Second() {

  const navigationLinks = [
    { path: '/', text: 'Root Page' },
    { path: '/third', text: 'Third Page' },
    { path: '/logs', text: 'Logs Page' },
    { path: '/logs/all', text: 'All Logs' }
  ]

  return (
    <div>
      <h1>Second Page</h1>
      <NavigationArea links={navigationLinks}></NavigationArea>
      <LoremText></LoremText>
    </div>
  )
}