open System.Net

let urlList =
    [ "http://www.louvre.fr/"
      "http://www.guggenheim.org/"
      "https://www.nga.gov/"
      "https://research.britishmuseum.org/"
      "https://naturalhistory.si.edu/"
      "https://www.metmuseum.org/"
      "https://www.salvador-dali.org/"
      "https://oh.larc.nasa.gov/oh/"
      "http://www.museivaticani.va/"
      "https://www.womenshistory.org/"
      "https://www.nationalmuseum.af.mil/" ]


[<EntryPoint>]
let main args =

    // Convert the below code to run asynchonously
    // Note: if done correctly all pages should start downloading
    // at once, significantly chaing the output.

    for url in urlList do
        printfn $"Starting download of '{url}' ..."
        let wc = new WebClient()
        let result = wc.DownloadString(url)
        printfn $"Finised downloading '{url}' got {result.Length} characters."


    // if you finish this quickly trying and use this technique to implement a
    // web crawler. The web crawler should extract links from each page and
    // follow them.

    0
