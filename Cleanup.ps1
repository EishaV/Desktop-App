$lst = "obj", "bin", "mobj", "mono"

foreach( $dir in dir -Directory -Path $PSScriptRoot ) {
  #Write-Output $dir.FullName

  foreach( $sub in $lst ) {
    $del = $dir.FullName + "\" + $sub
    if( Test-Path -Path $del ) {
      Remove-Item $del -Recurse
      Write-Output "$del deleted"
    }
  }
}