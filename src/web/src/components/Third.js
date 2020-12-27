import React from 'react'
import LoremText from './LoremText'
import NavigationArea from './NavigationArea'

export default function Third() {

  const navigationLinks = [
    { path: '/', text: 'Root Page' },
    { path: '/second', text: 'Second Page' },
    { path: '/logs', text: 'Logs Page' },
    { path: '/logs/all', text: 'All Logs' }
  ]

  return (
    <div>
      <h1>Third Page</h1>
      <NavigationArea links={navigationLinks}></NavigationArea>
      <LoremText></LoremText>
    </div>
  )
}